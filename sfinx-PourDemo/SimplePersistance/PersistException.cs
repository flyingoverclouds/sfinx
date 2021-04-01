using System;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Description résumée de PersistException.
	/// </summary>
	public class PersistException : ApplicationException
	{
		public PersistException() : base()
		{
		}

		public PersistException(string message) : base(message)
		{
		}

	}
}
