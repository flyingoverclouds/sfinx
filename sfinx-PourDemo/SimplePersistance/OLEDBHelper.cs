using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using SableFin.SfinX.SimplePersistance;

namespace SableFin.SfinX.DBHelper
{
	/// <summary>
	/// Description résumée de OLEDBHelper.
	/// </summary>
	public class OLEDBHelper : IDBContextHelper
	{
		public OLEDBHelper()
		{
			//
			// TODO : ajoutez ici la logique du constructeur
			//
		}


		private OleDbConnection connection=null;
		private OleDbTransaction transaction=null;

		public IDbConnection GetConnection(string cnxStr)
		{
			if (connection==null)
			{
				connection=new OleDbConnection(cnxStr);
				connection.Open();
			}
			return(connection);
		}


		public IDbCommand GetNewCommand(string request)
		{
			return new OleDbCommand(request);
		}

		public void AddParameter(IDbCommand command,string parameterName,SqlDbType dbType,object parameterValue)
		{
			OleDbCommand cmd=command as OleDbCommand;
			OleDbParameter p=cmd.Parameters.Add(parameterName,dbType);
			p.Value=parameterValue;
		}

		public  void AddParameter(IDbCommand command,string parameterName,SqlDbType dbType,object parameterValue,ParameterDirection direction)
		{
			AddParameter(command,parameterName,dbType,parameterValue);
			((OleDbParameter)command.Parameters[parameterName]).Direction=direction;
		}


		public  object GetParameterValue(IDataParameter param)
		{
			return ((OleDbParameter)param).Value;
		}


		public  IDbTransaction GetTransaction()
		{
			if (transaction!=null) return transaction;
			if (connection==null) throw new PersistException("No current connection");
			transaction=connection.BeginTransaction();
			return transaction;
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

		public  void CloseConnection()
		{
			if (transaction!=null) 
				throw new PersistException("Cannot CloseConnection : a transaction is open");
			if (connection!=null) 
				connection.Close();
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
