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
	/// Classe chargé de l'acces à la base de données de géré la persistance des données ( DataAccessLayer ).
	/// Le developpeur utilisera les méthode Read, Insert, Update, Delete pour gérer la persistance de son objet.
	/// </summary>
	public sealed class  PersistDAL
	{
		/// <summary>
		/// contient la référence a l'instance du DBhelper a utilisé pour l'instance de persistDAL en cours d'execution
		/// </summary>
		private IDBContextHelper dbhelper=null;

		/// <summary>
		/// stocke le type de DBHelper qu'utiliseront les instance de PersistDAL lors des opération de persistance
		/// </summary>
		static private Type p_defaultDbhelperType=null;

		/// <summary>
		/// Propriété indiquant le type de DBHelper a utiliser pour la persistance.
		/// Par defaut : null
		/// </summary>
		static public Type DBHelper
		{
			get { return p_defaultDbhelperType; }
			set { p_defaultDbhelperType=value; }
		}


		/// <summary>
		/// contient une collection d'objet PersistCacheItem.
		/// Le clé correspont au nom complet (FullyQualifiedName) du type de donnée et de son assembly correspondante
		/// </summary>
		static private SortedList _slTypeInfoCache=new SortedList();

		
		/// <summary>
		/// Stocke le booléen indiquant si le cache d'info sur les type de données doit etre activé
		/// </summary>
		static private bool _typeInfoCacheEnable=false;

		/// <summary>
		/// propriété indiquant l'état d'activation du cache des informations de mapping relationnel/objet.
		/// True : active le cache
		/// False : desactive le cache (valeur par défaut)
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
		/// Permet d'indiquer le connexion String Provider à utiliser.
		/// </summary>
		static public IConnectionStringProvider ConnectionStringProvider
		{
			get { return p_connectionStringProvider; }
			set { p_connectionStringProvider=value; }
		}

		/// <summary>
		/// Initialise les données statiques utilisées pour la Persistance.
		/// Si un AppSetting appelé "PersistDAL.DBHelper" est défini, le type correspondant est affecté 
		/// à la propriété DBHelper.
		/// </summary>
		static PersistDAL()
		{
			//on tente de lire dans le fichier de config le type de DBHelper a utilisé.
			// si on en trouve un , on mémorise le Type correspondant
			if (System.Configuration.ConfigurationSettings.AppSettings["PersistDAL.DBHelper"]!=null)
				DBHelper=Type.GetType(System.Configuration.ConfigurationSettings.AppSettings["PersistDAL.DBHelper"]);
			if (System.Configuration.ConfigurationSettings.AppSettings["PersistDAL.TypeInfoCacheEnable"]!=null)
				PersistDAL.TypeInfoCacheEnable=(System.Configuration.ConfigurationSettings.AppSettings["PersistDAL.DBHelper"]=="true")?true:false;

		}

		/// <summary>
		/// constructeur d'instance. Déclarer internal pour n'autoriser l'instanciation que via une méthode
		/// statique de la classe.
		/// Une fois l'instance de créée, un DBHelper du type défini est instancié pour cette instance.
		/// </summary>
		internal PersistDAL()
		{
			if (p_defaultDbhelperType==null)
				throw new PersistException("You need to set a dbhelper type : PersistDAL.DBHelperType=null");
			this.dbhelper=(IDBContextHelper)Activator.CreateInstance(p_defaultDbhelperType); //new SqlServerContextHelper();	// defautl DBHelper
		}

		/// <summary>
		/// Cette fonction permet de récupérer les informations d'acces à la base de données tel que 
		/// préciser dans les attributs d'une classe Persistable.
		/// </summary>
		/// <param name="persistableObjectType">Type dont on souhaite récupérer les infos</param>
		/// <param name="pdsa">contient l'instance de l'attribut PersistsDataSource de la classe</param>
		/// <param name="pcs">contient l'instance de l'attribut PersistsConnexionString de la classe</param>
		private void GetDatabaseInformation(Type persistableObjectType,out PersistDataSourceAttribute pdsa, out PersistConnectionStringAttribute pcs)
		{
			pdsa=null;	// contient les requetes utile pour l'acces au données
			pcs=null;	// contient l'attribut de la chaine de connexion


			#region Gestion du cache pour PCS et PDSA
			PersistCacheItem ci=null;	// pour stocker l'item du cache si besoin
			if (TypeInfoCacheEnable)
			{
				if (_slTypeInfoCache.Contains(persistableObjectType.AssemblyQualifiedName))
				{
					// les informations pour ce type de données sont déjà présentes dans le cache.
					ci=(PersistCacheItem)_slTypeInfoCache[persistableObjectType.AssemblyQualifiedName];
					// si pdsa & pcs sont différents de null, on renvoi directement ces valeurs
					if (ci.pcs!=null && ci.pdsa!=null) 
					{
						pdsa=ci.pdsa;
						pcs=ci.pcs;
						return;
					}
				}
				else
				{
					// le cache ne contient les données pour ce type => on ajout un nouveau persistCacheItem dans le cache
					ci=new PersistCacheItem();
					_slTypeInfoCache.Add(persistableObjectType.AssemblyQualifiedName,ci);
				}
			}
			#endregion



			MemberInfo objInfo=persistableObjectType;
			/* recherche des informations de persistance lié à la classe : recherche de l'attribut [PersistDataSource] */
			object[] tabAttrs=objInfo.GetCustomAttributes(true);
			foreach(object obj in tabAttrs)
			{
				if (obj is PersistDALAttribute)
				{
					if (pdsa==null)
						pdsa=obj as PersistDataSourceAttribute; // si obj est un [PersistDataSource] on stocke sa référence
					if (pcs==null)		
						pcs=obj as PersistConnectionStringAttribute;	// on stocke la ref a l'attribut si c'est une [PersistConnectionString] 
					// pour recupérer la chaine de connection a utiliser
				}
			}
			if (pdsa==null)	// si pas de [PersistDataSource] sur la classe ==> Erreur : pas persistable
				throw new PersistException("Not a persistable class, or class without PersistDataSourceAttribute inherited attribute");
			if (pcs==null)	// si pas de [PersistConnectionString] sur la classe ==> Erreur pas d'info de connexion à la base
				throw new PersistException("No ConnectionString information for accessing DataBase");

			#region Gestion du cache pour PCS et PDSA
			// on met a jour les info du CacheItem et on l'ajoute dans le cache si cache activé
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
						// cas d'attribut d'aggrégation : on stocke l'objet référence ajoute dans la liste de objets a aggrégé, 
						// ainsi que le mapping des clé a utiliser pour le chargement des données
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
		/// Ces informations sont agrégé dans 2 collection en utilisant des instance de PersistFieldInfo afin
		/// d'optimiser l'utilisation de la reflexion. 
		/// </summary>
		/// <param name="persistableObject">reférence sur l'objet a persiter. Doit etre marque avec un attribut [PersisDataSource]</param>
		/// <param name="alPrimaryKeys">renvoi un ArrayList contenant la liste des clé primaire déclaré dans l'obj a persister </param>
		/// <param name="slFieldsValue">renvoi une SortedList contenant l'ensemble des informations necessaire pour effectué les 4 opération de persistance.</param>
		/// <param name="alAggregatedObject">renvoi la liste des objets aggrégé</param>
		private void CreateFieldAndPKeyList(Type persistableObjectType,
			out ArrayList alPrimaryKeys, out SortedList slFieldsValue)
		{
			alPrimaryKeys=new ArrayList();	// contient la liste des clés primaire
			slFieldsValue=new SortedList();// contient la liste des champs et leur valeurs



			#region Gestion du cache pour alPrimaryKey,slFieldsValue et alAggregatedObject
			PersistCacheItem ci=null;	// pour stocker l'item du cache si besoin
			if (TypeInfoCacheEnable)
			{
				if (_slTypeInfoCache.Contains(persistableObjectType.AssemblyQualifiedName))
				{
					// les informations pour ce type de données sont déjà présentes dans le cache.
					ci=(PersistCacheItem)_slTypeInfoCache[persistableObjectType.AssemblyQualifiedName];
					// si pdsa & pcs sont différents de null, on renvoi directement ces valeurs
					if (ci.alPrimaryKeys!=null && ci.slFieldsValue!=null) 
					{
						alPrimaryKeys=ci.alPrimaryKeys;
						slFieldsValue=ci.slFieldsValue;
						return;
					}
				}
				else
				{
					// le cache ne contient les données pour ce type => on ajout un nouveau persistCacheItem dans le cache
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
						// on ajoute le nom du parametreADO et les infos associé
						if (((DBFieldAttribute)obj).PrimaryKey) // si le flag clé primaire de l'attribut est vrai, 
							// on ajoute le nom du parametre ADO dans la liste des clés 1aire
						{
							alPrimaryKeys.Add((obj as DBFieldAttribute).DBFieldName);
						}
					}
				}
			}

			//====================================================================== pour les PROPERTIES
			PropertyInfo[] tabProperties=persistableObjectType.GetProperties();
			foreach(PropertyInfo pi in tabProperties) // on parcours chaque propriété de la classe
			{
				object[] tabAttrsField=pi.GetCustomAttributes(true);	// pour la propriété en cours, on recupere ses attributs 
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

						if (((DBFieldAttribute)obj).PrimaryKey) // si le flag clé primaire de l'attribut est vrai, 
							// on ajoute le nom du parametre ADO dans la liste des clés 1aire
						{
							alPrimaryKeys.Add((obj as DBFieldAttribute).DBFieldName);
						}
					}
				}
			}
			
			#region Gestion du cache pour alPrimaryKey,slFieldsValue et alAggregatedObject
			// on met a jour les info du CacheItem et on l'ajoute dans le cache si cache activé
			if (ci!=null)
			{
				ci.alPrimaryKeys=alPrimaryKeys;
				ci.slFieldsValue=slFieldsValue;
			}
			#endregion		

		
		}



		#region READ
		/// <summary>
		/// Méthode static pour appelé p_Read. 
		/// Cf p_Read() pour plus d'infos.
		/// </summary>
		/// <param name="persistableObject"></param>
		static public void Read(object persistableObject)
		{
			PersistDAL dal=new PersistDAL();	// on créer une instance qui sera chargé du traitement
			dal.p_Read(persistableObject);
			dal.dbhelper.CloseConnection();
			dal=null;
		}


		/// <summary>
		/// Cette méthode réalise la lecture de l'objet a partir des valeur des champs marqué comme cle primaire.
		/// </summary>
		/// <param name="persistableObject">reference de l'objet a lire. Les champs marqué comme clé primaire doivent etre rempli.</param>
		internal void p_Read(object persistableObject)
		{
			if (dbhelper==null) throw new ApplicationException("You need to set a DBHelpContext instance : PesistDAL.DBHelper=null");

			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au données
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des clés primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			// on crée les commandes d'acces à la base de données et la collection de parametre ADO a utilisé
			pdsa.GenerateCommands(persistableObject,dbhelper, alPrimaryKeys,slFieldsValue);

			// on se connecte a la base de donnée en utilisant la chaine de connection présent dans l'attribut [PersistConnectionString]
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
			// recupération du contenu des champs
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

				// TODO : affecter au champs de l'object principal la valeur du l'objet agréré

				//CreateFieldAndPKeyList(persistableObject,out alPrimaryKeys,out slFieldsValue,null);
				//SetPrimaryKey(aggregatedObject,alPrimaryKeys,slFieldsValue);	// on pose les valeurs des clés primaire
				//p_Read(aggregatedObject);	// on lit l'objet
			}

			dbhelper.GetConnection(pcs.ConnectionString).Close();
		}


		#endregion


		#region UPDATE

		/// <summary>
		/// Méthode static pour mettre a jour un objet 
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
		/// <param name="persistableObjects">tableau d'objet persistable à mettre a jour</param>
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
		/// Cette méthode réalise la mise a jour de l'objet a partir des valeur des champs.
		/// </summary>
		/// <param name="persistableObject">reference de l'objet a mettre a jour. Les champs marqué comme clé primaire doivent etre valide.</param>
		internal void p_Update_internal(object persistableObject)
		{
			if (dbhelper==null) throw new ApplicationException("You need to set a DBHelpContext instance : PesistDAL.DBHelper=null");
			
			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au données
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des clés primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);

			// on recupere les noms de collone & leur valeur
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			// on crée les commandes d'acces à la base de données et la collection de parametre ADO a utilisé
			pdsa.GenerateCommands(persistableObject, dbhelper,alPrimaryKeys,slFieldsValue);

			// on execute la commande de lecture d'un objet
			pdsa.UpdateCommand.Connection=dbhelper.GetConnection(pcs.ConnectionString);
			pdsa.UpdateCommand.Transaction=dbhelper.GetTransaction();
			if (pdsa.UpdateCommand.ExecuteNonQuery()<1)
				throw new ApplicationException("No record updated");

			foreach(object aggregatedObject in alAggregatedObjects)	// on parcours la liste des objets aggregé et on les updates a leur tour
			{
				p_Update_internal(aggregatedObject);				
			}
		}



		#endregion


		#region INSERT

		/// <summary>
		/// Méthode static pour appelé p_Insert. 
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
		/// Cette méthode réalise l'insertion de l'objet a partir des valeur des champs.
		/// </summary>
		/// <param name="persistableObject">reference de l'instance de l'objet a insérer. Les champs marqué comme clé primaire doivent etre valide.</param>
		internal void p_Insert_internal(object persistableObject)
		{
			if (dbhelper==null) throw new ApplicationException("You need to set a DBHelpContext instance : PesistDAL.DBHelper=null");

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au données
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des clés primaire
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

			// on crée les commandes d'acces à la base de données et la collection de parametre ADO a utilisé
			pdsa.GenerateCommands(persistableObject,dbhelper,alPrimaryKeys,slFieldsValue);

			// on execute la commande de lecture d'un objet
			pdsa.InsertCommand.Connection=dbhelper.GetConnection(pcs.ConnectionString);
			pdsa.InsertCommand.Transaction=dbhelper.GetTransaction();
			pdsa.InsertCommand.ExecuteNonQuery();

			// recupération des champs identity
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
		/// Méthode static pour appelé p_Delete. 
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
		/// Méthode static pour appelé p_Delete. 
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
		/// Cette méthode réalise la suppression de l'objet a partir des valeur des champs.
		/// </summary>
		/// <param name="persistableObject">reference de l'objet a supprimer de la base. Les champs marqué comme clé primaire doivent etre valide.</param>
		public void p_Delete_internal(object persistableObject)
		{
			if (dbhelper==null) throw new ApplicationException("You need to set a DBHelpContext instance : PesistDAL.DBHelper=null");
			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au données
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des clés primaire
			SortedList slFieldsValue;// contient la liste des champs et leur valeurs

			Type persistableObjectType=persistableObject.GetType();	// on recupere les informations sur le type de l'objet a persister

			ArrayList alAggregatedObjects=GetAggregatedObject(persistableObject);
			GetDatabaseInformation(persistableObjectType,out pdsa,out pcs);
			CreateFieldAndPKeyList(persistableObjectType,out alPrimaryKeys,out slFieldsValue);

			// on crée les commandes d'acces à la base de données et la collection de parametre ADO a utilisé
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

			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au données
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des clés primaire
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
			// on se connecte a la base de donnée en utilisant la chaine de connection présent dans l'attribut [PersistConnectionString]
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
			PersistDAL dal=new PersistDAL();	// on créer une instance qui sera chargé du traitement
			return dal.p_ReadMultiple(persistableObject,top,where,orderby,groupby);
		}

		internal ArrayList p_ReadMultiple(object persistableObject,string top,string where,string orderby,string groupby)
		{
			PersistDataSourceAttribute pdsa;	// contient les requetes utile pour l'acces au données
			PersistConnectionStringAttribute pcs;	// contient l'attribut de la chaine de connexion
			ArrayList alPrimaryKeys;	// contient la liste des clés primaire
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

			// on se connecte a la base de donnée en utilisant la chaine de connection présent dans l'attribut [PersistConnectionString]
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
