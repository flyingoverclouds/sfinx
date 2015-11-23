using System;
using System.Data;
using System.Collections;

namespace SableFin.SfinX.DBHelper
{
	/// <summary>
	/// Classe abstraite indiquant les méthodes implémenté par les classes DBHelper
	/// </summary>
	public interface IDBContextHelper
	{
		IDbConnection GetConnection(string cnxStr);
		IDbCommand GetNewCommand(string request);
		void AddParameter(IDbCommand command,string parameterName,SqlDbType dbType,object parameterValue);
		void AddParameter(IDbCommand command,string parameterName,SqlDbType dbType,object parameterValue,ParameterDirection direction);
		object GetParameterValue(IDataParameter param);

		IDbTransaction GetTransaction();
		void Commit();
		void Rollback();
		void CloseConnection();

		string GetSQLSelect(ArrayList primaryKeys,SortedList fieldsValue,string tableName);
		string GetSQLInsert(ArrayList primaryKeys,SortedList fieldsValue,string tableName);
		string GetSQLUpdate(ArrayList primaryKeys,SortedList fieldsValue,string tableName);
		string GetSQLDelete(ArrayList primaryKeys,SortedList fieldsValue,string tableName);
		
	}
}
