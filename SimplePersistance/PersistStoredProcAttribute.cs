using System;
using System.Collections;
using System.Data;
using SableFin.SfinX.DBHelper;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// attribut heritant indiquant une persistance via des procedures stockée.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class , AllowMultiple=false)]
	public class PersistStoredProcAttribute : PersistDataSourceAttribute
	{
		public PersistStoredProcAttribute(string SELECTStoredProcName)	: base() // au moins le select est obligatoire
		{
			this.SELECTStoredProc=SELECTStoredProcName;
		}

		public string SELECTStoredProc
		{
			get { return p_ct_select; }
			set { p_ct_select=value; }
		}

		public string INSERTStoredProc
		{
			get { return p_ct_insert; }
			set { p_ct_insert=value; }
		}
		public string UPDATEStoredProc
		{
			get { return p_ct_update; }
			set { p_ct_update=value; }
		}
		public string DELETEStoredProc
		{
			get { return p_ct_delete; }
			set { p_ct_delete=value; }
		}


		public override void GenerateCommands(object persistableObject,IDBContextHelper helper,ArrayList PrimaryKeys,SortedList FieldValue)
		{
			// crée les 4 Commandes SQL pour l'execution des proc stock ainsi que La listes des paramètres 

			if (p_ct_select!=null) // creation d'une requete SELECT ?
			{
				// creation de la requete Select
				p_cmdSelect=helper.GetNewCommand(p_ct_select);
				p_cmdSelect.CommandType=CommandType.StoredProcedure;

				// creation des parametres de la requete
				foreach(string spparamname in PrimaryKeys)
				{
						helper.AddParameter(p_cmdSelect,"@" + spparamname,
							((PersistFieldInfo)(FieldValue[spparamname])).DBType,
							((PersistFieldInfo)(FieldValue[spparamname])).DBValue(persistableObject));
				}
			}
		
			if (p_ct_insert!=null) // creation d'une requete INSERT ?
			{
				// creation de la requete Insert
				p_cmdInsert=helper.GetNewCommand(p_ct_insert);
				p_cmdInsert.CommandType=CommandType.StoredProcedure;

				// creation des parametres de la requete
				foreach(string spparamname in FieldValue.Keys)
				{
					if (((PersistFieldInfo)(FieldValue[spparamname])).Identity==true)
					{
						helper.AddParameter(p_cmdInsert,"@" + spparamname,
							((PersistFieldInfo)(FieldValue[spparamname])).DBType,
							((PersistFieldInfo)(FieldValue[spparamname])).DBValue(persistableObject),
							ParameterDirection.Output);
					}
					else
					{
						helper.AddParameter(p_cmdInsert,"@" + spparamname,
							((PersistFieldInfo)(FieldValue[spparamname])).DBType,
							((PersistFieldInfo)(FieldValue[spparamname])).DBValue(persistableObject));
					}
				}
			}
		
		
			if (p_ct_update!=null) // creation d'une requete UPDATE ?
			{
				// creation de la requete Update
				p_cmdUpdate=helper.GetNewCommand(p_ct_update);
				p_cmdUpdate.CommandType=CommandType.StoredProcedure;

				// creation des parametres de la requete
				foreach(string spparamname in FieldValue.Keys)
				{
					PersistFieldInfo pfi=(PersistFieldInfo)(FieldValue[spparamname]);
					helper.AddParameter(p_cmdUpdate,"@" + spparamname,pfi.DBType,pfi.DBValue(persistableObject));
				}
			}
		
		
			if (p_ct_delete!=null) // creation d'une requete DELETE ?
			{
				// creation de la requete Delete
				p_cmdDelete=helper.GetNewCommand(p_ct_delete);
				p_cmdDelete.CommandType=CommandType.StoredProcedure;

				// creation des parametres de la requete
				foreach(string spparamname in PrimaryKeys)
				{
					helper.AddParameter(p_cmdDelete,"@" + spparamname,
						((PersistFieldInfo)(FieldValue[spparamname])).DBType,
						((PersistFieldInfo)(FieldValue[spparamname])).DBValue(persistableObject));
				}
			}
		}


	
	}
}
