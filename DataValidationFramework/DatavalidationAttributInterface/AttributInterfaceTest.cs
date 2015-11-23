using System;

namespace DatavalidationAttributInterface
{
	/// <summary>
	/// Description résumée de AttributInterfaceTest.
	/// </summary>
	public class AttributInterfaceTest
	{

		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("** Attribut et Interface");
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
