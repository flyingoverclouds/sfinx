using System;

namespace SableFin.SfinX.SimplePersistance
{


	/// <summary>
	/// classe abstraite. Tout attribut impl�mentant des fonctions de la librairie de Persistance doit
	/// h�rit� de cette classe.
	/// </summary>
	public abstract class PersistDALAttribute : System.Attribute
	{
		public PersistDALAttribute() : base() {}
	}


}
