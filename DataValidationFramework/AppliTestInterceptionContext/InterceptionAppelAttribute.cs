using System;
using System.Runtime.Remoting.Contexts;	
using System.Runtime.Remoting.Activation;

namespace AppliTestInterceptionContext
{
	/// <summary>
	/// On crée un attribu de context indiquant que la classe doit s'executer 
	/// dans un contexte supportant l'interception des appels.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class InterceptionAppelAttribute : ContextAttribute
	{
		public InterceptionAppelAttribute() : base("InterceptionAppelAttribute")
		{
			
		}


		// Permet d'ajouter des propriétés dans un nouveau contexte
		// ( Une propriété est un peu l'équivalent des shared properties utilisable avec COM+ dans ComponentServices )
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
		{
			InterceptionAppelProperty intercepProp = new InterceptionAppelProperty();
			ctor.ContextProperties.Add(intercepProp);
		}


		//Le runtime .NET interroge l'attribut pour savoir si le contexte courant est valide.
		//Si cette fonction renvoi false, le runtime créé un nouveau contexte et appelle GetPropertiesForNewContext()
		// pour vérifier si le context est valid, on vérifie la présence (et la validité si besoin) d'une propriété
		public override bool IsContextOK(Context ctx,IConstructionCallMessage ctorMsg) 
		{ 
			//le return false permet de forcer systématiquement un nouveau contexte pour chaqueinstance
			// utilise si une instance d'un type créé des instance de ce meme type : vous pouvez intercepter
			// les appels entre instance d'un meme type ( car il y aura changement de contexte )
			//return false;	

			InterceptionAppelProperty prop=ctx.GetProperty("InterceptionAppelProperty") as InterceptionAppelProperty;
			if (prop!=null)	// on a une propriété appelé InterceptionAppelProperty dans le contexte ?
				return true;	// Oui -> on accepte le contexte

			return false;	// Non -> on refuse le contexte
		}

	}
}
