using System;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlClient;
using System.Data;

namespace Sablefin.SFINx.SimplePersistance
{
	/// <summary>
	/// Description résumée de PersistContextProperty.
	/// </summary>
	public class PersistContextProperty : IContextProperty
	{
		private string p_ctxPropName="";
		private SqlTransaction p_trans=null;
		private SqlConnection p_cnx=null;

		public string Name 
		{ 
			get { return p_ctxPropName; }
		}

		public void Freeze(Context newContext)
		{
			return;	
		}

		public bool IsNewContextOK(Context newCtx)
		{
			return true;
		}

		public PersistContextProperty(string propertyName,SqlConnection cnx,SqlTransaction trans)
		{
			p_ctxPropName=propertyName;
			p_trans=trans;
			p_cnx=cnx;
		}
	}
}
