using System;
using System.Data;
using System.Data.SqlClient;

namespace SableFin.SfinX.SimplePersistance
{
	/// <summary>
	/// Attribut indiquand le nom de la colonne a utiliser pour mapper un champ de l'objet, 
	/// le type base de données a utiliser. Il sert aussi a indique si il s'agit d'un clé primaire
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,AllowMultiple=false)]
	public class DBFieldAttribute : PersistDALAttribute
	{
		private string p_fieldName;
		private bool p_primaryKey;
		private bool p_identity;
		private SqlDbType p_fieldType=SqlDbType.VarChar;
		private bool p_nullable=false;

		public DBFieldAttribute(string fieldName)	// le nom de la collone
		{
			p_fieldName=fieldName;
			p_primaryKey=false;
			p_identity=false;
		}

		public DBFieldAttribute(string fieldName,SqlDbType fieldType)	// le nom de la collone et son type
			: this(fieldName)
		{
			p_fieldType=fieldType;
		}

		public string DBFieldName
		{
			get { return p_fieldName; }
		}

		public SqlDbType DBFieldType
		{
			get { return p_fieldType; }
			set { p_fieldType=value; }
		}

		/// <summary>
		/// Indique si le champ est de type compteur automatique. Dans ce cas, il ne sera pas pris en compte lors de l'insert/update
		/// </summary>
		public bool Identity
		{
			get { return p_identity; }
			set { p_identity=value; }
		}

		/// <summary>
		/// Propriété booleenne indiquant si le champ se comporte comme une clé primaire.
		/// </summary>
		public bool PrimaryKey
		{
			get { return p_primaryKey; }
			set { p_primaryKey = value; }
		}


		/// <summary>
		/// Permet de savoir si le champ supporte la valeur null.
		/// Par default non (FALSE)
		/// </summary>
		public bool IsNullable
		{
			set { p_nullable=value; }
			get { return p_nullable; }
		}

		// TODO : implémenter la possibilité de forcer le nom du champ indiquant le null
		public string NullFieldName
		{
			set { throw new PersistException("changing the NullFieldName value is not supported in this release");}
			get { return p_fieldName + "ISNULL"; }
		}

	}
}
