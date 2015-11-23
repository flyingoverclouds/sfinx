using System;

namespace AppliTestInterceptionContext
{
	/// <summary>
	/// La classe ObjetDemo est un Object dont on souhaite pouvoir intercepter les appels à ses méthodes.
	/// </summary>
	[InterceptionAppel]
	public class ObjetDemo : ContextBoundObject
	{
		public ObjetDemo()
		{
			// initialisation de la commande (pour test)
			_numero="20040101000000A";
		}

		private string _numero;	
		public string Numero
		{
			get { return _numero;}
			set { _numero=value;}
		}

	
		public int DoSomething(string uneChaineDeCaractere)
		{
			return 1972;
		}
		public ObjetDemo DoSomething2()
		{
			return new ObjetDemo();
		}

	}
}
