using System;
using System.Runtime.Remoting.Contexts;	
using System.Runtime.Remoting.Activation;

namespace SableFin.SfinX.DataValidation
{
	/// <summary>
	/// On crée un attribut de context indiquant que la classe doit s'executer 
	/// dans un contexte supportant la validation des données
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class DataValidationAttribute : ContextAttribute
	{
		public DataValidationAttribute() : base("DataValidationAttribute")
		{
			
		}


		// Permet d'ajouter des propriétés dans un nouveau contexte
		// ( Une propriété est un peu l'équivalent des shared properties utilisable avec COM+ dans ComponentServices )
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
		{
			DataValidationProperty validProp = new DataValidationProperty();
			ctor.ContextProperties.Add(validProp);
		}


		//Le runtime .NET interroge pour savoir si le contexte courant est valide.
		//Si cette fonction false, le runtime créé un nouveau contexte et appelle GetPropertiesForNewContext()
		// pour vérifier si le context est valid, on vérifie la présence (et la validité si besoin) d'un propriété
		public override bool IsContextOK(Context ctx,IConstructionCallMessage ctorMsg) 
		{ 
			//return false;	// Seulement si vous souhaitez un contexte par instance !
			DataValidationProperty prop=ctx.GetProperty("DataValidation") as DataValidationProperty;
			if (prop!=null)	// on a une propriété appelé ValidationData dans le contexte ?
				return true;	// Oui -> on accepte le contexte

			return false;	// Non -> on refuse le contexte
		}

	}
}
