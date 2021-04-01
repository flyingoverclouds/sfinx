using System;

namespace SableFin.SfinX.DataValidation
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

		/// <summary>
		/// recuperation d'un message d'erreur pret a afficher
		/// </summary>
		/// <returns>string : message d'erreur</returns>
		string GetValidationFailureMessage();

		/// <summary>
		/// recuperation sous une forme textuelle du détail de la contrainte
		/// </summary>
		/// <returns>forme textuelle de la contrainte</returns>
		string GetConstraintDetails();
	}
}
