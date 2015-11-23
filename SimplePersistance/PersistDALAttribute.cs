using System;

namespace SableFin.SfinX.SimplePersistance
{


	/// <summary>
	/// classe abstraite. Tout attribut implémentant des fonctions de la librairie de Persistance doit
	/// hérité de cette classe.
	/// </summary>
	public abstract class PersistDALAttribute : System.Attribute
	{
		public PersistDALAttribute() : base() {}
	}


}
