using System;

namespace DatavalidationAttributInterface
{
	/// <summary>
	/// Cette interface, lorsqu'elle est implémenté par une attribut, indique que cet attribut support les 
	/// fonction de validation des données de la propriété (ou parametre de méthode ) sur lequel il est appliqué
	/// </summary>
	public interface IDataValidationConstraint
	{
		/// <summary>
		/// Effectue la vérification sur l'instance passé en paramètre.
		/// </summary>
		/// <returns>true=la vérification est ok, false=erreur la verification a echouée</returns>
		bool DoCheck(object obj);

	}
}
