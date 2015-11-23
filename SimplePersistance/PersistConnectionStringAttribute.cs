using System;

using System.Configuration;
using System.Data;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// L'attribut PersistConnectionString sert a définir la chaine de connection a utiliser lors
	/// de la persistance de l'objet dans une base de donnéee.
	/// L'utilisation du parametre nommé AppSettingsName spécifie qu'elle clé du fichier de parametrage de l'appli contient la chaine de connexion
	/// L'utilisation du paremetre nommé ConnectionString permet de spécifier directement dans le code la chaine de connexion.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct , AllowMultiple=false)]
	public class PersistConnectionStringAttribute : PersistDALAttribute
	{
		private string p_connectionString=null;

		public PersistConnectionStringAttribute() : base() 
		{
		}

		/// <summary>
		/// Indique quelle AppSettings contient la chaine de connexion
		/// </summary>
		public string AppSettingsName
		{
			set 
			{
				p_connectionString=System.Configuration.ConfigurationSettings.AppSettings[value];
			}
			get 
			{
				return "";
			}
		}

		/// <summary>
		/// Chaine de connexion qui sera utilisé pour la persistance.
		/// </summary>
		public string ConnectionString
		{
			set {p_connectionString=value;}
			get {
				if (p_connectionString==null && PersistDAL.ConnectionStringProvider!=null)
				{
					return PersistDAL.ConnectionStringProvider.GetConnectionString("");
				}
				return p_connectionString;
			}
		}

		/// <summary>
		/// Indique le nom de la variable de Session qui contient la chaine de connexion
		/// </summary>
		public string SessionVariable
		{
			set {
				System.Web.HttpContext ctx=System.Web.HttpContext.Current;
				if (ctx==null) throw new PersistException("PersistConnectionStringAttribute.SessionVariable : No HTTP context available");
				p_connectionString=(string)ctx.Session[value];
			}
			get 
			{
				return "";
			}
		}

	}


}
