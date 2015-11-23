using System;
using System.Collections;
using System.Data;
using SableFin.SfinX.DBHelper;

namespace SableFin.SfinX.SimplePersistance
{
	
	/// <summary>
	/// Attribut abstrait implémentant les fonctions et propriété pour accéder au source de données pour
	/// persister les objets.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct , AllowMultiple=false)]
	public abstract class PersistDataSourceAttribute : PersistDALAttribute
	{
		protected string p_ct_insert=null;
		protected string p_ct_update=null;
		protected string p_ct_delete=null;
		protected string p_ct_select=null;
		protected IDbCommand p_cmdInsert=null;
		protected IDbCommand p_cmdUpdate=null;
		protected IDbCommand p_cmdDelete=null;
		protected IDbCommand p_cmdSelect=null;
		protected string p_tableName=null;


		public PersistDataSourceAttribute() : base() 
		{
		}

		public string SelectCommandText
		{
			get { return p_ct_select; }
		}
		public string InsertCommandText
		{
			get { return p_ct_insert; }
		}
		public string UpdateCommandText
		{
			get { return p_ct_update; }
		}
		public string DeleteCommandText
		{
			get { return p_ct_delete; }
		}

		public IDbCommand SelectCommand
		{
			get { return p_cmdSelect; }
		}
		public IDbCommand InsertCommand
		{
			get { return p_cmdInsert; }
		}
		public IDbCommand UpdateCommand
		{
			get { return p_cmdUpdate; }
		}
		public IDbCommand DeleteCommand
		{
			get { return p_cmdDelete; }
		}

		public string TableName
		{
			get { return p_tableName; }
			set { p_tableName=value; }
		}

		public virtual void GenerateCommands(object persistableObject,IDBContextHelper helper,ArrayList PrimaryKeys,SortedList FieldValue)
		{	
		}


		public virtual void ExecuteRead(SortedList FieldValue)
		{
		}
	}


}
