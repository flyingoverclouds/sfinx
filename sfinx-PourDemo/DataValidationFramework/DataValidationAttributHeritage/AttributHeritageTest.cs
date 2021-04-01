using System;

namespace DataValidationAttributHeritage
{
	
	class AttributHeritageTest
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("** Attribut et Héritage");
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
