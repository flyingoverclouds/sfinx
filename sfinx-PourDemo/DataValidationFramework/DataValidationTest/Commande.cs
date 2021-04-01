using System;
using SableFin.SfinX.DataValidation;
using SableFin.SfinX.DataValidation.Constraint;

namespace SableFin.DataValidationTest
{
	/// <summary>
	/// La classe commande est censé modélisé une commande géré par le système.
	/// Elle hérite de ContextBoundObject car on souhaite effectué des interception d'appel, 
	/// notamment pour effectuer les vérifications de format et de validité des informations fournies.
	/// </summary>
	[DataValidation]
	public class Commande : ContextBoundObject
	{
		public Commande()
		{
			// initialisation de la commande (pour test)
			_numero="20040101000000A";
			_codePostal="69123";
			_codeClient="FR1";
			_totalHT=0.0;
		}

		private Guid _printedId=Guid.NewGuid();

		private string _numero;	// format : AAAAMMJJNNNNNC : AAAAMMJJ=date, NNNNN=numéro jour, C=code controle

		private string _codePostal;	// code postal

		private string _codeClient;	// format : PPIIIIII : P=code pays; IIIIII=num client

		private double _totalHT;	// total HT de la commande

		public string Numero
		{
			get { return _numero;}
			set { _numero=value;}
		}

		[ZipCode]
		public string CodePostal
		{
			get { return _codePostal;}
			set { _codePostal=value;}
		}

		
		public string CodeClient
		{
			get { return _codeClient;}
			set 
			{ 
				_codeClient=value; 
			}
		}

		[HigherOrEqualThan(0)]
		[LowerThan(2000)]
		public double TotalHT
		{
			get { return _totalHT;}
			
			
			set { 
				_totalHT=value;
			}
		}

		public Guid PrintedId
		{
			get { return _printedId;}
			
			
			set { _printedId=value;}
		}

		public int DoSomething(	[Length(3,10)]string customerID,[Length(0,100)]Guid printedId)
		{
			return 1972;
		}
	}
}
