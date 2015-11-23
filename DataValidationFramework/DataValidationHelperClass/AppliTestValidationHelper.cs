using System;

namespace DataValidationHelperClass
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	class AppliTestValidationHelper
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("** utilisation d'un Helper");
			//
			// TODO : ajoutez ici le code pour démarrer l'application
			//
			try 
			{
				Client cli=new Client();

				cli.CodePostal="69100";

				cli.CodePostal="DK1425";
			}
			catch(Exception exc)
			{
				Console.Write(exc.Message);
			}
		}
	}
}
