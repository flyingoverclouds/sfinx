using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using SableFin.SfinX.SimplePersistance;

namespace SableFin.SfinX.DBHelper
{
	/// <summary>
	/// Cette classe fournit les méthodes retourne les IDBxxxx referencant
	/// des objets SQLServer
	/// </summary>
	public class SqlServerContextHelper : IDBContextHelper
	{
		private SqlConnection connection=null;
		private SqlTransaction transaction=null;

		public  IDbConnection GetConnection(string cnxStr)
		{
			if (connection==null)
			{
				connection=new SqlConnection(cnxStr);
				connection.Open();
			}
			return(connection);
		}


		public  IDbCommand GetNewCommand(string request)
		{
			return new SqlCommand(request);
		}

		public  void AddParameter(IDbCommand command,string parameterName,SqlDbType dbType,object parameterValue)
		{
			SqlCommand cmd=command as SqlCommand;
			SqlParameter p=cmd.Parameters.Add(parameterName,dbType);
			p.Value=parameterValue;
		}

		public  void AddParameter(IDbCommand command,string parameterName,SqlDbType dbType,object parameterValue,ParameterDirection direction)
		{
			AddParameter(command,parameterName,dbType,parameterValue);
			((SqlParameter)command.Parameters[parameterName]).Direction=direction;
		}


		public  object GetParameterValue(IDataParameter param)
		{
			return ((SqlParameter)param).Value;
		}


		public  IDbTransaction GetTransaction()
		{
			if (transaction!=null) return transaction;
			if (connection==null) throw new PersistException("No current connection");
			transaction=connection.BeginTransaction();
			return transaction;
		}

		public  void CloseConnection()
		{
			if (transaction!=null) 
				throw new PersistException("Cannot CloseConnection : a transaction is open");
			if (connection!=null) 
				connection.Close();
		}

		public  void Commit()
		{
			if (connection==null) throw new PersistException("No current connection");
			if (transaction==null) throw new PersistException("No transaction to commit");
			transaction.Commit();
			transaction=null;
		}

		public  void Rollback()
		{
			if (connection==null) throw new PersistException("No current connection");		
			if (transaction==null) throw new PersistException("No transaction to rollback");
			transaction.Rollback();
			transaction=null;
		}

		public  string GetSQLSelect(ArrayList primaryKeys,SortedList fieldsValue,string tableName)
		{
			string spCols="";
			string spWhere="";

			foreach(string col in fieldsValue.Keys)
			{
				spCols+=",[" + col + "]";
				if (primaryKeys.Contains(col))
					spWhere+=" AND " + col + "=@" + col;
			}
			spCols=spCols.Remove(0,1);	// on supprime la "," en début de chaine
			spWhere=spWhere.Remove(0,5);	// on supprime le " AND " du début de la chaine
			return "SELECT " + spCols + " FROM " + tableName + " WHERE " + spWhere;
		}

		public  string GetSQLInsert(ArrayList primaryKeys,SortedList fieldsValue,string tableName)
		{
			string spCols="";
			string spValues="";

			foreach(string col in fieldsValue.Keys)
			{
				spCols+=",[" + col + "]";
				spValues+=",@" + col;
				
			}
			spCols=spCols.Remove(0,1);	// on supprime la "," en début de chaine
			spValues=spValues.Remove(0,1);	// on supprime la "," en début de la chaine
			return "INSERT INTO " + tableName + " (" + spCols + ") VALUES (" + spValues + ")";
		}
	
		public  string GetSQLUpdate(ArrayList primaryKeys,SortedList fieldsValue,string tableName)
		{
			string spCols="";
			string spWhere="";

			foreach(string col in fieldsValue.Keys)
			{
				spCols+=",[" + col + "]=@" + col;
				if (primaryKeys.Contains(col))
					spWhere+=",[" + col + "]=@" + col;
			}
			spCols=spCols.Remove(0,1);	// on supprime la "," en début de chaine
			spWhere=spWhere.Remove(0,1);	// on supprime la "," en début de la chaine
			return "UPDATE " + tableName + " SET " + spCols + " WHERE " + spWhere;
		}

		public  string GetSQLDelete(ArrayList primaryKeys,SortedList fieldsValue,string tableName)
		{
			string spWhere="";

			foreach(string col in primaryKeys)
			{
				spWhere+=" AND [" + col + "]=@" + col;
			}
			spWhere=spWhere.Remove(0,5);	// on supprime le " AND " du début de la chaine
			return "DELETE FROM " + tableName + " WHERE " + spWhere;
		}

	
	
	}
}
