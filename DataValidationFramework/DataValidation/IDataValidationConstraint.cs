using System;

namespace SableFin.SfinX.DataValidation
{
	/// <summary>
	/// Cette interface, lorsqu'elle est impl�ment� par une attribut, indique que cet attribut support les 
	/// fonction de validation des donn�es de la propri�t� (ou parametre de m�thode ) sur lequel il est appliqu�
	/// </summary>
	public interface IDataValidationConstraint
	{
		/// <summary>
		/// Effectue la v�rification sur l'instance pass� en param�tre.
		/// </summary>
		/// <returns>true=la v�rification est ok, false=erreur la verification a echou�e</returns>
		bool DoCheck(object obj);

		/// <summary>
		/// recuperation d'un message d'erreur pret a afficher
		/// </summary>
		/// <returns>string : message d'erreur</returns>
		string GetValidationFailureMessage();

		/// <summary>
		/// recuperation sous une forme textuelle du d�tail de la contrainte
		/// </summary>
		/// <returns>forme textuelle de la contrainte</returns>
		string GetConstraintDetails();
	}
}
