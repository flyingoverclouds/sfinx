using System;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Interface définissant la capacité qu'a une classe a fournir des chaines
	/// de connexion à la couche de Persistance.
	/// </summary>
	public interface IConnectionStringProvider
	{
		/// <summary>
		/// REnvoi la chaine de connexion à utiliser pour un type précis
		/// ATTENTION : pour l'instant ne gere que des fullyTypeName=""
		/// </summary>
		/// <param name="fullyTypeName">Nom complet du type de données</param>
		/// <returns>string: Chaine de connexion à utiliser</returns>
		string GetConnectionString(string fullyTypeName);
	}
}
