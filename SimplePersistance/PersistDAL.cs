using System;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using SableFin.SfinX.DBHelper;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Classe charg� de l'acces � la base de donn�es de g�r� la persistance des donn�es ( DataAccessLayer ).
	/// Le developpeur utilisera les m�thode Read, Insert, Update, Delete pour g�rer la persistance de son objet.
	/// </summary>
	public sealed class  PersistDAL
	{
		/// <summary>
		/// contient la r�f�rence a l'instance du DBhelper a utilis� pour l'instance de persistDAL en cours d'execution
		/// </summary>
		private IDBContextHelper dbhelper=null;

		/// <summary>
		/// stocke le type de DBHelper qu'utiliseront les instance de PersistDAL lors des op�ration de persistance
		/// </summary>
		static private Type p_defaultDbhelperType=null;

		/// <summary>
		/// Propri�t� indiquant le type de DBHelper a utiliser pour la persistance.
		/// Par defaut : null
		/// </summary>
		static public Type DBHelper
		{
			get { return p_defaultDbhelperType; }
			set { p_defaultDbhelperType=value; }
		}


		/// <summary>
		/// contient une collection d'objet PersistCacheItem.
		/// Le cl� correspont au nom complet (FullyQualifiedName) du type de donn�e et de son assembly correspondante
		/// </summary>
		static private SortedList _slTypeInfoCache=new SortedList();

		
		/// <summary>
		/// Stocke le bool�en indiquant si le cache d'info sur les type de donn�es doit etre activ�
		/// </summary>
		static private bool _typeInfoCacheEnable=false;

		/// <summary>
		/// propri�t� indiquant l'�tat d'activation du cache des informations de mapping relationnel/objet.
		/// True : active le cache
		/// False : desactive le cache (valeur par d�faut)
		/// </summary>
		static public bool TypeInfoCacheEnable
		{
			get { return _typeInfoCacheEnable; }
			set 
			{ 
				_typeInfoCacheEnable=value; 
				if (value==false)
					_slTypeInfoCache.Clear();	// on purge le cache des infos de persistance
			}
		}


		static private IConnectionStringProvider p_connectionStringProvider=null;

		/// <summary>
		/// Permet d'indiquer le connexion String Provider � utiliser.
		/// </summary>
		static public IConnectionStringProvider ConnectionStringProvider
		{
			get { return p_connectionStringProvider; }
			set { p_connectionStringProvider=value; }
		}

		/// <summary>
		/// Initialise les donn�es statiques utilis�es pour la Persistance.
		/// Si un AppSetting appel� "PersistDAL.DBHelper" est d�fini, le type correspondant est affect� 
		/// � la propri�t� DBHelper.
		/// </summary>
		static PersistDAL()
		{
			//on tente de lire dans le fichier de config le type de DBHelper a utilis�.
			// si on en trouve un , on m�morise le Type correspondant
			if (System.Configuration.ConfigurationSettings.AppSettings["PersistDAL.DBHelper"]!=null)
				DBHelper=Type.GetType(System.Configuration.ConfigurationSettings.AppSettings["PersistDAL.DBHelper"]);
			if (System.Configuration.ConfigurationSettings.AppSettings["PersistDAL.TypeInfoCacheEnable"]!=null)
				PersistDAL.TypeInfoCacheEnable=(System.Configuration.ConfigurationSettings.AppSettings["PersistDAL.DBHelper"]=="true")?true:false;

		}

		/// <summary>
		/// constructeur d'instance. D�clarer internal pour n'autoriser l'instanciation que via une m�thode
		/// statique de la classe.
		/// Une fois l'instance de cr��e, un DBHelper du type d�fini est instanci� pour cette instance.
		/// </summary>
		internal PersistDAL()
		{
			if (p_defaultDbhelperType==null)
				throw new PersistException("You need to set a dbhelper type : PersistDAL.DBHelperType=null");
			this.dbhelper=(IDBContextHelper)Activator.CreateInstance(p_defaultDbhelperType); //new SqlServerContextHelper();	// defautl DBHelper
		}

		/// <summary>
		/// Cette fonction permet de r�cup�rer les informations d'acces � la base de donn�es tel que 
		/// pr�ciser dans les attributs d'une classe Persistable.
		/// </summary>
		/// <param name="persistableObjectType">Type dont on souhaite r�cup�rer les infos</param>
		/// <param name="pdsa">contient l'instance de l'attribut PersistsDataSource de la classe</param>
		/// <param name="pcs">contient l'instance de l'attribut PersistsConnexionString de la classe</param>
		private void GetDatabaseInformation(Type persistableObjectType,out PersistDataSourceAttribute pdsa, out PersistConnectionStringAttribute pcs)
		{
			pdsa=null;	// contient les requetes utile pour l'acces au donn�es
			pcs=null;	// contient l'attribut de la chaine de connexion


			#region Gestion du cache pour PCS et PDSA
			PersistCacheItem ci=null;	// pour stocker l'item du cache si besoin
			if (TypeInfoCacheEnable)
			{
				if (_slTypeInfoCache.Contains(persistableObjectType.AssemblyQualifiedName))
				{
					// les informations pour ce type de donn�es sont d�j� pr�sentes dans le cache.
					ci=(PersistCacheItem)_slTypeInfoCache[persistableObjectType.AssemblyQualifiedName];
					// si pdsa & pcs sont diff�rents de null, on renvoi directement ces valeurs
					if (ci.pcs!=null && ci.pdsa!=null) 
					{
						pdsa=ci.pdsa;
						pcs=ci.pcs;
						return;
					}
				}
				else
				{
					// le cache ne contient les donn�es pour ce type => on ajout un nouveau persistCacheItem dans le cache
					ci=new PersistCacheItem();
					_slTypeInfoCache.Add(persistableObjectType.AssemblyQualifiedName,ci);
				}
			}
			#endregion



			MemberInfo objInfo=persistableObjectType;
			/* recherche des informations de persistance li� � la classe : recherche de l'attribut [PersistDataSource] */
			object[] tabAttrs=objInfo.GetCustomAttributes(true);
			foreach(object obj in tabAttrs)
			{
				if (obj is PersistDALAttribute)
				{
					if (pdsa==null)
						pdsa=obj as PersistDataSourceAttribute; // si obj est un [PersistDataSource] on stocke sa r�f�rence
					if (pcs==null)		
						pcs=obj as PersistConnectionStringAttribute;	// on stocke la ref a l'attribut si c'est une [PersistConnectionString] 
					// pour recup�rer la chaine de connection a utiliser
				}
			}
			if (pdsa==null)	// si pas de [PersistDataSource] sur la classe ==> Erreur : pas persistable
				throw new PersistException("Not a persistable class, or class without PersistDataSourceAttribute inherited attribute");
			if (pcs==null)	// si pas de [PersistConnectionString] sur la classe ==> Erreur pas d'info de connexion � la base
				throw new PersistException("No ConnectionString information for accessing DataBase");

			#region Gestion du cache pour PCS et PDSA
			// on met a jour les info du CacheItem et on l'ajoute dans le cache si cache activ�
			if (ci!=null)
			{
				ci.pdsa=pdsa;
				ci.pcs=pcs;
			}
			#endregion
		}
		

		private ArrayList GetAggregatedObject(object persistableObject)
		{
			ArrayList alAggregatedObject=new ArrayList();

			//====================================================================== pour les FIELDs
			FieldInfo[] tabFields=persistableObject.GetType().GetFields();
			foreach(FieldInfo fi in tabFields) // on parcours chaque champ de la classe
			{
				object[] tabAttrsField=fi.GetCustomAttributes(true);	// pour le champ en cours, on recupere ses attributs 
				foreach(object obj in tabAttrsField)
				{
					if (obj is Relation1NAttribute)
					{
						// cas d'attribut d'aggr�gation : on stocke l'objet r�f�rence ajoute dans la liste de objets a aggr�g�, 
						// ainsi que le mapping des cl� a utiliser pour le chargement des donn�es
						alAggregatedObject.Add(
							new PersistAggregationInfo(
							fi.GetValue(persistableObject),
							(obj as Relation1NAttribute).KeyMapping ,
							fi
							)
							);
					}
				}
			}
			return alAggregatedObject;
		}
		

		
		/// <summary>
		/// Cette fonction scan le l'objet a persister pour extraire les informations de persistance.
		/// Ces informations sont agr�g� dans 2 collection en utilisant des instance de PersistFieldInfo afin
		/// d'optimiser l'utilisation de la reflexion. 
		/// </summary>
		/// <param name="persistableObject">ref�rence sur l'objet a persiter. Doit etre marque avec un attribut [PersisDataSource]</param>
		/// <param name="alPrimaryKeys">renvoi un ArrayList contenant la liste des cl� primaire d�clar� dans l'obj a persister </param>
		/// <param name="slFieldsValue">renvoi une SortedList contenant l'ensemble des informations necessaire pour effectu� les 4 op�ration de persistance.</param>
		/// <param name="alAggregatedObject">renvoi la liste des objets aggr�g�</param>
		private void CreateFieldAndPKeyList(Type persistableObjectType,
			out ArrayList alPrimaryKeys, out SortedList slFieldsValue)
		{
			alPrimaryKeys=new ArrayList();	// contient la liste des cl�s primaire
			slFieldsValue=new SortedList();// contient la liste des champs et leur valeurs



			#region Gestion du cache pour alPrimaryKey,slFieldsValue et alAggregatedObject
			PersistCacheItem ci=null;	// pour stocker l'item du cache si besoin
			if (TypeInfoCacheEnable)
			{
				if (_slTypeInfoCache.Contains(persistableObjectType.AssemblyQualifiedName))
				{
					// les informations pour ce type de donn�es sont d�j� pr�sentes dans le cache.
					ci=(PersistCacheItem)_slTypeInfoCache[persistableObjectType.AssemblyQualifiedName];
					// si pdsa & pcs sont diff�rents de null, on renvoi directement ces valeurs
					if (ci.alPrimaryKeys!=null && ci.slFieldsValue!=null) 
					{
						alPrimaryKeys=ci.alPrimaryKeys;
						slFieldsValue=ci.slFieldsValue;
						return;
					}
				}
				else
				{
					// le cache ne contient les donn�es pour ce type => on ajout un nouveau persistCacheItem dans le cache
					ci=new PersistCacheItem();
					_slTypeInfoCache.Add(persistableObjectType.AssemblyQualifiedName,ci);
				}
			}
			#endregion


			//====================================================================== pour les FIELDs
			FieldInfo[] tabFields=persistableObjectType.GetFields();
			foreach(FieldInfo fi in tabFields) // on parcours chaque champ de la classe
			{
				object[] tabAttrsField=fi.GetCustomAttributes(true);	// pour le champ en cours, on recupere ses attributs 
				foreach(object obj in tabAttrsField)
				{
					if (obj is DBFieldAttribute)	// si le champ est un [PersistField]
					{
						DBFieldAttribute dbfa=obj as DBFieldAttribute;
						FieldInfo fi_IsNull=null;
						if (dbfa.IsNullable) // si X is nullable on recherche le FieldInfo pour la var XIsNull
						{
							fi_IsNull=persistableObjectType.GetField(dbfa.NullFieldName);
							if (fi_IsNull==null) throw new PersistException("boolean field [" + dbfa.NullFieldName +"] is missing in the [" + persistableObjectType.Name + "] persistable type.\r\nManaging NULL requires this boolean field. Please add it.");
						}
						slFieldsValue.Add(
							dbfa.DBFieldName, 
							new PersistFieldInfo( 
							dbfa.DBFieldName,
							dbfa.DBFieldType,
							dbfa.Identity,fi,
							fi_IsNull
							) 
							); 
						// on ajoute le nom du parametreADO et les infos associ�
						if (((DBFieldAttribute)obj).PrimaryKey) // si le flag cl� primaire de l'attribut est vrai, 
							// on ajoute le nom du parametre ADO dans la liste des cl�s 1aire
						{
							alPrimaryKeys.Add((obj as DBFieldAttribute).DBFieldName);
						}
					}
				}
			}

			//====================================================================== pour les PROPERTIES
			PropertyInfo[] tabProperties=persistableObjectType.GetProperties();
			foreach(PropertyInfo pi in tabProperties) // on parcours chaque propri�t� de la classe
			{
				object[] tabAttrsField=pi.GetCustomAttributes(true);	// pour la propri�t� en cours, on recupere ses attributs 
				foreach(object obj in tabAttrsField)
				{
					if (obj is DBFieldAttribute)	// si c'est un [DBField]
					{
						DBFieldAttribute dbfa=obj as DBFieldAttribute;
						FieldInfo fi_IsNull=null;
						if (dbfa.IsNullable) // si X is nullable on recherche le FieldInfo pour la var XIsNull
						{
							fi_IsNull=persistableObjectType.GetField(dbfa.NullFieldName);
						}
						slFieldsValue.Add(dbfa.DBFieldName, 
							new PersistFieldInfo( 
							dbfa.DBFieldName,
							dbfa.DBFieldType,
							dbfa.Identity,pi,
							fi_IsNull
							) ); 

						if (((DBFieldAttribute)obj).PrimaryKey) // si le flag cl� primaire de l'attribut est vrai, 
							// on ajoute le nom du parametre ADO dans la liste des cl�s 1aire
						{
							alPrimaryKeys.Add((obj as DBFieldAttribute).DBFieldName);
						}
					}
				}
			}
			
			#region Gestion du cache pour alPrimaryKey,slFieldsValue et alAggregatedObject
			// on met a jour les info du CacheItem et on l'ajoute dans le cache si cache activ�
			if (ci!=null)
			{
				ci.alPrimaryKeys=alPrimaryKeys;
				ci.slFieldsValue=slFieldsValue;
			}
			#endregion		

		
		}



		#region READ
		/// <summary>
		/// M�thode static pour appel� p_Read. 
		/// Cf p_Read() pour plus d'infos.
		/// </summary>
		/// <param name="persistableObject"></param>
		static public void Read(object persistableObject)
		{
			PersistDAL dal=new PersistDAL();	// on cr�er une instance qui sera charg� du traitement
			dal.p_Read(persistableObject);
			dal.dbhelper.CloseConnection();
			dal=null;
		}


		/// <summary>
		/// Cette m�thode r�alise la lecture de l'objet a partir des valeur des champs marqu� comme cle primaire.
		/// </summary>
		/// <param name="persistableObject">reference de l'objet a lire. Les champs marqu� comme cl� primaire doivent etre rempli.</param>
		internal void p_Read(object persistableObject)
		{
			if (dbhelper==null) throw new ApplicationException("You need to set a DBHelpContext instance : PesistDAL.DBHelper=null");

			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au donn�es
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des cl�s primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			// on cr�e les commandes d'acces � la base de donn�es et la collection de parametre ADO a utilis�
			pdsa.GenerateCommands(persistableObject,dbhelper, alPrimaryKeys,slFieldsValue);

			// on se connecte a la base de donn�e en utilisant la chaine de connection pr�sent dans l'attribut [PersistConnectionString]
			IDbConnection cnx=dbhelper.GetConnection(pcs.ConnectionString);

			// on execute la commande de lecture d'un objet
			pdsa.SelectCommand.Connection=cnx;
			IDataReader rdr=pdsa.SelectCommand.ExecuteReader();
			if (rdr.Read()==false)
			{
				rdr.Close();
				cnx.Close();
				throw new ApplicationException("No record found");
			}
			// recup�ration du contenu des champs
			PersistFieldInfo pfi; 
			foreach(string k in slFieldsValue.Keys)
			{
				pfi=(PersistFieldInfo)slFieldsValue[k];
				pfi.SetInstanceValue(persistableObject,rdr[k]);
			}

			// fermeture
			rdr.Close();
			rdr=null;

			// on traite les aggregated object 
			foreach(PersistAggregationInfo pai in alAggregatedObjects)
			{
				//MessageBox.Show(pai.AggregatedObject.GetType().FullName);
				string where="";
				string separator="";

				foreach(KeyMappingInfo kmi in pai.KeyMapping)
				{
					object keyvalue=(slFieldsValue[kmi.SourceField] as PersistFieldInfo).GetInstanceValue(persistableObject);
					if (keyvalue is string)
						where+=separator + kmi.TargetField + "='" + keyvalue.ToString() +"'";
					else
						where+=separator + kmi.TargetField + "=" + keyvalue.ToString();
					separator=" AND ";
				}
				//MessageBox.Show(where);

				ArrayList alrm=p_ReadMultiple(pai.AggregatedObject,null,where,null,null);
				pai.SetInstanceValue(persistableObject,alrm[0]);

				// TODO : affecter au champs de l'object principal la valeur du l'objet agr�r�

				//CreateFieldAndPKeyList(persistableObject,out alPrimaryKeys,out slFieldsValue,null);
				//SetPrimaryKey(aggregatedObject,alPrimaryKeys,slFieldsValue);	// on pose les valeurs des cl�s primaire
				//p_Read(aggregatedObject);	// on lit l'objet
			}

			dbhelper.GetConnection(pcs.ConnectionString).Close();
		}


		#endregion


		#region UPDATE

		/// <summary>
		/// M�thode static pour mettre a jour un objet 
		/// </summary>
		/// <param name="persistableObject">l'objet a mettre a jour dans la base</param>
		static public void Update(object persistableObject)
		{
			if (persistableObject is IEnumerable)
				PersistDAL.Update(persistableObject as IEnumerable);
			else
				PersistDAL.Update(new object[] { persistableObject } );
		}

		/// <summary>
		/// Methode statique update permettant de grouper l'update de plusieur objets au sein de la meme
		/// transaction.
		/// </summary>
		/// <param name="persistableObjects"></param>
		static public void Update(IEnumerable persistableObjects)
		{
			PersistDAL dal=new PersistDAL();
			dal.p_Update(persistableObjects);
			dal.dbhelper.Commit();
			dal.dbhelper.CloseConnection();
			dal=null;
		}


		/// <summary>
		/// Methode d'instance update permettant de grouper l'update de plusieur objets au sein de la meme
		/// transaction.
		/// </summary>
		/// <param name="persistableObjects">tableau d'objet persistable � mettre a jour</param>
		internal void p_Update(IEnumerable persistableObjects)
		{
			// appel des traitement
			try
			{
				foreach(object o in persistableObjects)
					p_Update_internal(o);
			}
			catch (Exception exc)
			{
				dbhelper.Rollback();
				throw exc;
			}
		}


		/// <summary>
		/// Cette m�thode r�alise la mise a jour de l'objet a partir des valeur des champs.
		/// </summary>
		/// <param name="persistableObject">reference de l'objet a mettre a jour. Les champs marqu� comme cl� primaire doivent etre valide.</param>
		internal void p_Update_internal(object persistableObject)
		{
			if (dbhelper==null) throw new ApplicationException("You need to set a DBHelpContext instance : PesistDAL.DBHelper=null");
			
			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au donn�es
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des cl�s primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);

			// on recupere les noms de collone & leur valeur
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			// on cr�e les commandes d'acces � la base de donn�es et la collection de parametre ADO a utilis�
			pdsa.GenerateCommands(persistableObject, dbhelper,alPrimaryKeys,slFieldsValue);

			// on execute la commande de lecture d'un objet
			pdsa.UpdateCommand.Connection=dbhelper.GetConnection(pcs.ConnectionString);
			pdsa.UpdateCommand.Transaction=dbhelper.GetTransaction();
			if (pdsa.UpdateCommand.ExecuteNonQuery()<1)
				throw new ApplicationException("No record updated");

			foreach(object aggregatedObject in alAggregatedObjects)	// on parcours la liste des objets aggreg� et on les updates a leur tour
			{
				p_Update_internal(aggregatedObject);				
			}
		}



		#endregion


		#region INSERT

		/// <summary>
		/// M�thode static pour appel� p_Insert. 
		/// Cf p_Insert() pour plsu d'infos.
		/// </summary>
		/// <param name="persistableObject"></param>
		static public void Insert(object persistableObject)
		{
			if (persistableObject is IEnumerable)
				PersistDAL.Insert(persistableObject as IEnumerable);
			else
				PersistDAL.Insert(new object[] { persistableObject } );
		}


		static public void Insert(IEnumerable persistableObjects)
		{
			PersistDAL dal=new PersistDAL();
			dal.p_Insert(persistableObjects);
			dal.dbhelper.Commit();
			dal.dbhelper.CloseConnection();
			dal=null;
		}


		//internal void p_Insert(object[] persistableObjects)
		internal void p_Insert(IEnumerable persistableObjects)
		{
			// appel des traitement
			try
			{
				foreach(object o in persistableObjects)
					p_Insert_internal(o);
			}
			catch (Exception exc)
			{
				dbhelper.Rollback();
				throw exc;
			}
		}
	

		/// <summary>
		/// Cette m�thode r�alise l'insertion de l'objet a partir des valeur des champs.
		/// </summary>
		/// <param name="persistableObject">reference de l'instance de l'objet a ins�rer. Les champs marqu� comme cl� primaire doivent etre valide.</param>
		internal void p_Insert_internal(object persistableObject)
		{
			if (dbhelper==null) throw new ApplicationException("You need to set a DBHelpContext instance : PesistDAL.DBHelper=null");

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au donn�es
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des cl�s primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs
			
			ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			foreach(object aggregatedObj in alAggregatedObjects)
			{
				try
				{
					p_Insert_internal(aggregatedObj);
				}
				catch(SqlException sqlexc)
				{
					if (sqlexc.Number==0x80131904)	// primary key deja existante
					{
						p_Update_internal(aggregatedObj);	// donc on fait un update
					}
					else throw sqlexc;

				}
			}

			// on cr�e les commandes d'acces � la base de donn�es et la collection de parametre ADO a utilis�
			pdsa.GenerateCommands(persistableObject,dbhelper,alPrimaryKeys,slFieldsValue);

			// on execute la commande de lecture d'un objet
			pdsa.InsertCommand.Connection=dbhelper.GetConnection(pcs.ConnectionString);
			pdsa.InsertCommand.Transaction=dbhelper.GetTransaction();
			pdsa.InsertCommand.ExecuteNonQuery();

			// recup�ration des champs identity
			PersistFieldInfo pfi; 
			foreach(string k in slFieldsValue.Keys)
			{
				pfi=(PersistFieldInfo)slFieldsValue[k];
				if (pfi.Identity==false) continue;	// si pas identity : on passe au param suivant
				object value=((SqlParameter)(pdsa.InsertCommand.Parameters["@"+pfi.DBFieldName])).Value;
				if (value==null)
					throw new ApplicationException("PersistDAL.p_Insert_internal : value of identity field could not be DBNull");
				pfi.SetInstanceValue(persistableObject,value);
			}
			
		}

		#endregion


		#region DELETE

		/// <summary>
		/// M�thode static pour appel� p_Delete. 
		/// Cf p_Delete() pour plus d'infos.
		/// </summary>
		/// <param name="persistableObject"></param>
		static public void Delete(object persistableObject)
		{
			if (persistableObject is IEnumerable)
				PersistDAL.Delete(persistableObject as IEnumerable);
			else
				PersistDAL.Delete( new object[] { persistableObject } );

		}

		/// <summary>
		/// M�thode static pour appel� p_Delete. 
		/// Cf p_Delete() pour plus d'infos.
		/// </summary>
		/// <param name="persistableObject"></param>
		static public void Delete(IEnumerable persistableObjects)
		{
			PersistDAL dal=new PersistDAL();
			dal.p_Delete(persistableObjects);
			dal=null;
		}



		public void p_Delete(IEnumerable persistableObjects)
		{
			// appel des traitements
			try
			{
				foreach(object o in persistableObjects)
					p_Delete_internal(o);
			}
			catch (Exception exc)
			{
				dbhelper.Rollback();
				throw exc;
			}
			// cloture la transaction du contexte
			dbhelper.Commit();

		}

		/// <summary>
		/// Cette m�thode r�alise la suppression de l'objet a partir des valeur des champs.
		/// </summary>
		/// <param name="persistableObject">reference de l'objet a supprimer de la base. Les champs marqu� comme cl� primaire doivent etre valide.</param>
		public void p_Delete_internal(object persistableObject)
		{
			if (dbhelper==null) throw new ApplicationException("You need to set a DBHelpContext instance : PesistDAL.DBHelper=null");
			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au donn�es
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des cl�s primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			// on cr�e les commandes d'acces � la base de donn�es et la collection de parametre ADO a utilis�
			pdsa.GenerateCommands(persistableObject,dbhelper,alPrimaryKeys,slFieldsValue);

			// on execute la commande de lecture d'un objet
			pdsa.DeleteCommand.Connection=dbhelper.GetConnection(pcs.ConnectionString);
			pdsa.DeleteCommand.Transaction=dbhelper.GetTransaction();
			if (pdsa.DeleteCommand.ExecuteNonQuery()<1)
				throw new ApplicationException("No record found");
		}

		#endregion


		static public void ClearCache()
		{
			_slTypeInfoCache.Clear();
		}

		#region QUERY
		static public ArrayList Query(Type persistableObjectType,params SQLRequestElement[] sqle)
		{
			PersistDAL dal=new PersistDAL();
			return dal.p_Query(persistableObjectType,sqle);

		}
		
		internal ArrayList p_Query(Type persistableObjectType,params SQLRequestElement[] sqle)
		{
			throw new PersistException("Not implemented");

			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au donn�es
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des cl�s primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs


			//ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);

			// on recupere les infos sur les cle primaires
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			ArrayList alMultObject=new ArrayList();

			// ICI : appel du dbhelper pour contruire la requete SQL !
			string reqSql="";
//////			if (top!=null) reqSql+=" TOP " + top;
//////
//////			reqSql+=" ";
//////			
//////			string separateur="";
//////			foreach(string pk in alPrimaryKeys)
//////			{
//////				PersistFieldInfo pfi=(PersistFieldInfo)slFieldsValue[pk];
//////				reqSql+=separateur + pfi.DBFieldName;
//////				separateur=",";
//////			}
//////			if (groupby!=null) reqSql+=separateur+groupby;
//////
//////			reqSql+=" FROM " + pdsa.TableName;
//////			if (where!=null) reqSql+=" WHERE " + where;
//////			if (groupby!=null) reqSql+=" GROUP BY " + groupby;
//////			if (orderby!=null) reqSql+=" ORDER BY " + orderby;
//////
			// on se connecte a la base de donn�e en utilisant la chaine de connection pr�sent dans l'attribut [PersistConnectionString]
			IDbConnection cnx=dbhelper.GetConnection(pcs.ConnectionString);
			IDbCommand cmd=dbhelper.GetNewCommand(reqSql);
			cmd.Connection=cnx;
			IDataReader rdr=cmd.ExecuteReader();
			Type tpo=persistableObjectType;
			while(rdr.Read())
			{
				SortedList slNewFieldValue=new SortedList();
				object npo=Activator.CreateInstance(tpo);
				foreach(string pk in alPrimaryKeys)
				{
					PersistFieldInfo pfi=(PersistFieldInfo)slFieldsValue[pk];
					pfi.SetInstanceValue(npo,rdr[pfi.DBFieldName]);
				}
				PersistDAL.Read(npo);
				alMultObject.Add(npo);
			}
			rdr.Close();
			rdr.Dispose();
			cmd.Dispose();
			dbhelper.GetConnection("").Close();

			return alMultObject;

		}

		#endregion



		#region READMULTIPLE

		[Obsolete("ReadMultiple is obsolete. In the future, use Query method",false)]
		static public ArrayList ReadMultiple(object persistableObject,string top,string where,string orderby,string groupby)
		{
			PersistDAL dal=new PersistDAL();	// on cr�er une instance qui sera charg� du traitement
			return dal.p_ReadMultiple(persistableObject,top,where,orderby,groupby);
		}

		internal ArrayList p_ReadMultiple(object persistableObject,string top,string where,string orderby,string groupby)
		{
			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au donn�es
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des cl�s primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);

			// on recupere les infos sur les cle primaires
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			ArrayList alMultObject=new ArrayList();
			string reqSql="SELECT";
			if (top!=null) reqSql+=" TOP " + top;

			reqSql+=" ";
			
			string separateur="";
			foreach(string pk in alPrimaryKeys)
			{
				PersistFieldInfo pfi=(PersistFieldInfo)slFieldsValue[pk];
				reqSql+=separateur + pfi.DBFieldName;
				separateur=",";
			}
			if (groupby!=null) reqSql+=separateur+groupby;

			reqSql+=" FROM " + pdsa.TableName;
			if (where!=null) reqSql+=" WHERE " + where;
			if (groupby!=null) reqSql+=" GROUP BY " + groupby;
			if (orderby!=null) reqSql+=" ORDER BY " + orderby;

			// on se connecte a la base de donn�e en utilisant la chaine de connection pr�sent dans l'attribut [PersistConnectionString]
			IDbConnection cnx=dbhelper.GetConnection(pcs.ConnectionString);
			IDbCommand cmd=dbhelper.GetNewCommand(reqSql);
			cmd.Connection=cnx;
			IDataReader rdr=cmd.ExecuteReader();
			Type tpo=persistableObject.GetType();
			while(rdr.Read())
			{
				SortedList slNewFieldValue=new SortedList();
				object npo=Activator.CreateInstance(tpo);
				foreach(string pk in alPrimaryKeys)
				{
					PersistFieldInfo pfi=(PersistFieldInfo)slFieldsValue[pk];
					pfi.SetInstanceValue(npo,rdr[pfi.DBFieldName]);
				}
				PersistDAL.Read(npo);
				alMultObject.Add(npo);
			}
			rdr.Close();
			rdr.Dispose();
			cmd.Dispose();
			dbhelper.GetConnection("").Close();

			return alMultObject;
		}

		#endregion


		private void DEBUGListAttributeAndValue(object b)
		{
			string txt="";
			
			FieldInfo[] tabFields=b.GetType().GetFields();
			foreach(FieldInfo fi in tabFields) // on parcours chaque champ de la classe
			{
				txt+=(fi.Name)+"\r\n";
				object[] tabAttrsField=fi.GetCustomAttributes(true);	// pour le champ en cours, on recupere ses attributs 
				foreach(object obj in tabAttrsField)
				{
					txt+="    [" + obj.GetType().Name+"]"+"\r\n";
					if (obj is DBFieldAttribute)	// si le champ est un [PersistField]
					{
						txt+="        DBFieldName = " + (obj as DBFieldAttribute).DBFieldName+"\r\n"; 
						txt+="        DBFieldType = " + (obj as DBFieldAttribute).DBFieldType+"\r\n"; 
						if ((obj as DBFieldAttribute).PrimaryKey)
							txt+="        IsPrimaryKey"+"\r\n"; 
					}
				}
			}
			MessageBox.Show(txt);
		}


	
	}
}
