using System;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// classe de base pour les elements decrivant la requete SQL a execut�
	/// </summary>
	public abstract class SQLRequestElement
	{
	}

	public class SQLLike : SQLRequestElement
	{
		public SQLLike(object field)
		{
			
		}
	}
}
