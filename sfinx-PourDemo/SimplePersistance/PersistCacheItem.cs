using System;
using System.Collections;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Description r�sum�e de PersistCacheItem.
	/// </summary>
	public class PersistCacheItem
	{
		public PersistDataSourceAttribute pdsa= null;
		public PersistConnectionStringAttribute pcs=null;
		public ArrayList alPrimaryKeys=null;
		public SortedList slFieldsValue=null;
	}
}
