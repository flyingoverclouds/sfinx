using System;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Description résumée de KeyMapping.
	/// </summary>
	public class KeyMappingInfo
	{
		private string p_sourceField;
		private string p_targetField;
		public KeyMappingInfo(string keyMapping)
		{
			string[] km=keyMapping.Split(':');
			p_sourceField=km[0];
			p_targetField=km[1];
		}

		public string SourceField
		{
			get { return p_sourceField; }
		}
		public string TargetField
		{
			get { return p_targetField; }
		}
	}
}
