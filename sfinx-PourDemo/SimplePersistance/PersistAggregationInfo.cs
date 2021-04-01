using System;
using System.Collections;
using System.Reflection;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Stocke les informations sur un objet aggréga dans une classe :
	///		reference a l'instance
	///		mapping des clés à appliquer
	/// </summary>
	public class PersistAggregationInfo
	{
		protected MemberInfo p_mi;
		private object p_aggregatedObject=null;
		private ArrayList p_alKeyMapping=new ArrayList();

		public PersistAggregationInfo(object aggregatedObject,string[] keyMapping,MemberInfo mi)
		{
			p_aggregatedObject=aggregatedObject;
			p_mi=mi;
			foreach(string mapping in keyMapping)
				p_alKeyMapping.Add(new KeyMappingInfo(mapping));
		}

		public object AggregatedObject
		{
			get { return p_aggregatedObject; }
		}

		public ArrayList KeyMapping
		{
			get { return p_alKeyMapping; }
		}

		public void SetInstanceValue(object persistableObject,object value)
		{
			if (p_mi==null)
				throw new PersistException("PersistAggregationInfo.SetInstanceValue() : no MemberInfo available");
			if (value is System.DBNull)
			{
				if (p_mi is FieldInfo)
					((FieldInfo)p_mi).SetValue(persistableObject,null);
				if (p_mi is PropertyInfo)
					((PropertyInfo)p_mi).SetValue(persistableObject,null,null);
			}
			else
			{
				if (p_mi is FieldInfo)
					((FieldInfo)p_mi).SetValue(persistableObject,value);
				if (p_mi is PropertyInfo)
					((PropertyInfo)p_mi).SetValue(persistableObject,value,null);
			}
		}


	}
}
