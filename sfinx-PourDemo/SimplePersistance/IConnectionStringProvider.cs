using System;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Interface d�finissant la capacit� qu'a une classe a fournir des chaines
	/// de connexion � la couche de Persistance.
	/// </summary>
	public interface IConnectionStringProvider
	{
		/// <summary>
		/// REnvoi la chaine de connexion � utiliser pour un type pr�cis
		/// ATTENTION : pour l'instant ne gere que des fullyTypeName=""
		/// </summary>
		/// <param name="fullyTypeName">Nom complet du type de donn�es</param>
		/// <returns>string: Chaine de connexion � utiliser</returns>
		string GetConnectionString(string fullyTypeName);
	}
}
