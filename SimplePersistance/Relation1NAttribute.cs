using System;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Classe indiquant une classe agrégée
	/// </summary>
	[AttributeUsage(AttributeTargets.Field,AllowMultiple=false)]
	public class Relation1NAttribute : PersistDALAttribute
	{
		private string[] p_keyMapping=null;
		//bool p_autoagregate=true;

		/// <summary>
		/// utilisation du mapping explicite entre tablePK et tableFK
		/// </summary>
		/// <param name="PKFKmapping">tableau de chaine de caractere definissant le mapping
		/// entre les PK et les FK.
		/// Formalisme : "PKname:FKname"
		/// </param>
		public Relation1NAttribute(string[] PKFKmapping)
		{
			p_keyMapping=PKFKmapping;
		}

		/// <summary>
		/// utilisation du mapping explicite entre tablePK et tableFK avec une seule clé
		/// </summary>
		/// <param name="PKFKmapping">tableau de chaine de caractere definissant le mapping
		/// entre les PK et les FK.
		/// Formalisme : "PKname:FKname"
		/// </param>
		public Relation1NAttribute(string PKFKmapping)
		{
			p_keyMapping=new string[] { PKFKmapping };
		}

		public string[] KeyMapping
		{
			get { return p_keyMapping; }
		}


//		/// <summary>
//		/// indique si l'agregation est géré automatique lors des acces DB
//		/// </summary>
//		public bool AutoAggregate		
//		{
//			get { return p_autoagregate; }
//			set { p_autoagregate=value; }
//		}

	}
}
