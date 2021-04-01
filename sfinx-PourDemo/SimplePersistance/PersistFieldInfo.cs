using System;
using System.Data;
using System.Reflection;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Classe interne utilisé pour mémoriser les informations de type sur un champ d'un classe lors du processus de persistance.
	/// </summary>
	internal class PersistFieldInfo 
	{
		protected string p_DBFieldName;
		protected bool p_identity;
		protected MemberInfo p_mi;
		protected SqlDbType p_DBType;
		protected MemberInfo p_miIsNull=null; // si !=null ==> le champ est nullable

		public PersistFieldInfo(string DBFieldName,SqlDbType dbType, bool IsIdentity,MemberInfo mi,MemberInfo miIsNull)
		{
			p_DBFieldName=DBFieldName;
			p_DBType=dbType;
			p_identity=IsIdentity;
			p_mi=mi;
			p_miIsNull=miIsNull;
		}

		public void SetInstanceValue(object persistableObject,object value)
		{
			if (p_mi==null)
				throw new PersistException("PersistFieldInfo.SetInstanceValue() : no MemberInfo available");

			if (value==System.DBNull.Value && p_miIsNull!=null) // null supporté sur le champ et NULL affecté
			{
				((FieldInfo)p_miIsNull).SetValue(persistableObject,true);	// on positionne le flag null a true
			}
			else
			{
				//p_DBValue=value;
				if (p_mi is FieldInfo)
					((FieldInfo)p_mi).SetValue(persistableObject,value);
				if (p_mi is PropertyInfo)
					((PropertyInfo)p_mi).SetValue(persistableObject,value,null);
			}
		}

		public object GetInstanceValue(object persistableObject)
		{
			if (p_mi is FieldInfo)
				return (p_mi as FieldInfo).GetValue(persistableObject);
			if (p_mi is PropertyInfo)
				(p_mi as PropertyInfo).GetValue(persistableObject,null);
			return null;
		}


		public string DBFieldName 	{ get {return p_DBFieldName;} }



		public object DBValue(object persistableObject)
		{
			object dbv;
			if (p_miIsNull!=null)
			{
				if ((bool)(p_miIsNull as FieldInfo).GetValue(persistableObject)==true)	// si le champ IsNull
					return System.DBNull.Value;
			}
			PropertyInfo pi=(p_mi as PropertyInfo);
			if (pi!=null)
				dbv=(pi as PropertyInfo).GetValue(persistableObject,null);
			else
			{
				FieldInfo fi=(p_mi as FieldInfo);
				if (fi!=null)
					dbv=(fi as FieldInfo).GetValue(persistableObject);
				else 
					throw new PersistException("INTERNAL ERROR : PersistFieldInfo.DBValue : fi must be FieldInfo or PropertyInfo type");
			}
			if (dbv==null) return System.DBNull.Value;
			return dbv;
		}

		public MemberInfo Mi 	{ get { return p_mi; } }
		public MemberInfo MiIsNull { get { return p_miIsNull; } }
		public SqlDbType DBType { get { return p_DBType; } }
		public bool Identity { get { return p_identity; } }
	
	}
}
