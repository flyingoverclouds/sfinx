using System;
using SableFin.SfinX.DataValidation;

namespace SableFin.DataValidationTest
{
	/// <summary>
	/// Description résumée de PerfObjectContextBounded.
	/// </summary>
	[DataValidation]
	public class PerfObjectContextBounded : ContextBoundObject
	{
		public PerfObjectContextBounded()
		{
			//
			// TODO : ajoutez ici la logique du constructeur
			//
		}

		private long _v=0;

		public long v
		{
			get { return _v; }
			set { _v=value; }
		}
	}
}
