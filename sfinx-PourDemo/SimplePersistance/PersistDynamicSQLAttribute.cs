using System;
using System.Collections;
using System.Data;
using SableFin.SfinX.DBHelper;

namespace SableFin.SfinX.SimplePersistance
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
	public class PersistDynamicSQLAttribute : PersistDataSourceAttribute
	{
		public PersistDynamicSQLAttribute(string tableName)
		{
			this.TableName=tableName;
		}

		public override void GenerateCommands(object persistableObject,IDBContextHelper helper,ArrayList PrimaryKeys,SortedList FieldValue)
		{
			// crée les 4 Commandes SQL pour l'execution des proc stock ainsi que La listes des paramètres 

			p_ct_select=helper.GetSQLSelect(PrimaryKeys,FieldValue,TableName);
			if (p_ct_select!=null) // creation d'une requete SELECT ?
			{
				// creation de la requete Select
				p_cmdSelect=helper.GetNewCommand(p_ct_select);
				p_cmdSelect.CommandType=CommandType.Text;

				// creation des parametres de la requete
				foreach(string spparamname in PrimaryKeys)
				{
					helper.AddParameter(p_cmdSelect,"@" + spparamname,
						((PersistFieldInfo)(FieldValue[spparamname])).DBType,
						((PersistFieldInfo)(FieldValue[spparamname])).DBValue(persistableObject));
				}
			}
	
			p_ct_insert=helper.GetSQLInsert(PrimaryKeys,FieldValue,TableName);
			if (p_ct_insert!=null) // creation d'une requete INSERT ?
			{
				// creation de la requete Insert
				p_cmdInsert=helper.GetNewCommand(p_ct_insert);
				p_cmdInsert.CommandType=CommandType.Text;

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
	
	
			p_ct_update=helper.GetSQLUpdate(PrimaryKeys,FieldValue,TableName);
			if (p_ct_update!=null) // creation d'une requete UPDATE ?
			{
				// creation de la requete Update
				p_cmdUpdate=helper.GetNewCommand(p_ct_update);
				p_cmdUpdate.CommandType=CommandType.Text;

				// creation des parametres de la requete
				foreach(string spparamname in FieldValue.Keys)
				{
					PersistFieldInfo pfi=(PersistFieldInfo)(FieldValue[spparamname]);
					helper.AddParameter(p_cmdUpdate,"@" + spparamname,pfi.DBType,pfi.DBValue(persistableObject));
				}
			}
	
	
			p_ct_delete=helper.GetSQLDelete(PrimaryKeys,FieldValue,TableName);
			if (p_ct_delete!=null) // creation d'une requete DELETE ?
			{
				// creation de la requete Delete
				p_cmdDelete=helper.GetNewCommand(p_ct_delete);
				p_cmdDelete.CommandType=CommandType.Text;

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
