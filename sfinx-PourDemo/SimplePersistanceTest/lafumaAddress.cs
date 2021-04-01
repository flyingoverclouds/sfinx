using System;
using System.Data;
using SableFin.SfinX.SimplePersistance;
    

namespace Sablefin.SFINx.SimplePersistanceTest
{
    
		// Persistable classes for the ADRESSE table.
		[PersistConnectionString(ConnectionString="user id=sa;password=JmFdT69;data source=WSQL2000-DMZ;initial catalog=LAFUMA-CUSTOMER")]
		[PersistStoredProc("spS_ADRESSE", INSERTStoredProc="spI_ADRESSE", DELETEStoredProc="spD_ADRESSE", UPDATEStoredProc="spU_ADRESSE", TableName="ADRESSE")]
		public class Adresse 
		{
        
			private int p_ADR_CLIE_ID;
        
			private short p_ADR_SITE_ID;
        
			private short p_ADR_CIVL_ID;
        
			private string p_ADR_NOM;
        
			private string p_ADR_PRENOM;
        
			private string p_ADR_MOT_PASSE;
        
			private string p_ADR_ADRESSE_1;
        
			private string p_ADR_ADRESSE_2;
        
			private string p_ADR_CODE_POSTAL;
        
			private string p_ADR_VILLE;
        
			private string p_ADR_PAYS_CODE;
        
			private string p_ADR_TEL;
        
			private System.DateTime p_ADR_DT_NAISSANCE;
        
			[DBField("ADR_CLIE_ID", PrimaryKey=true)]
			public int ADR_CLIE_ID 
			{
				get 
				{
					return this.p_ADR_CLIE_ID;
				}
				set 
				{
					this.p_ADR_CLIE_ID = value;
				}
			}
        
			[DBField("ADR_SITE_ID", PrimaryKey=true)]
			public short ADR_SITE_ID 
			{
				get 
				{
					return this.p_ADR_SITE_ID;
				}
				set 
				{
					this.p_ADR_SITE_ID = value;
				}
			}
        
			[DBField("ADR_CIVL_ID")]
			public short ADR_CIVL_ID 
			{
				get 
				{
					return this.p_ADR_CIVL_ID;
				}
				set 
				{
					this.p_ADR_CIVL_ID = value;
				}
			}
        
			[DBField("ADR_NOM")]
			public string ADR_NOM 
			{
				get 
				{
					return this.p_ADR_NOM;
				}
				set 
				{
					this.p_ADR_NOM = value;
				}
			}
        
			[DBField("ADR_PRENOM")]
			public string ADR_PRENOM 
			{
				get 
				{
					return this.p_ADR_PRENOM;
				}
				set 
				{
					this.p_ADR_PRENOM = value;
				}
			}
        
			[DBField("ADR_MOT_PASSE")]
			public string ADR_MOT_PASSE 
			{
				get 
				{
					return this.p_ADR_MOT_PASSE;
				}
				set 
				{
					this.p_ADR_MOT_PASSE = value;
				}
			}
        
			[DBField("ADR_ADRESSE_1")]
			public string ADR_ADRESSE_1 
			{
				get 
				{
					return this.p_ADR_ADRESSE_1;
				}
				set 
				{
					this.p_ADR_ADRESSE_1 = value;
				}
			}
        
			[DBField("ADR_ADRESSE_2")]
			public string ADR_ADRESSE_2 
			{
				get 
				{
					return this.p_ADR_ADRESSE_2;
				}
				set 
				{
					this.p_ADR_ADRESSE_2 = value;
				}
			}
        
			[DBField("ADR_CODE_POSTAL")]
			public string ADR_CODE_POSTAL 
			{
				get 
				{
					return this.p_ADR_CODE_POSTAL;
				}
				set 
				{
					this.p_ADR_CODE_POSTAL = value;
				}
			}
        
			[DBField("ADR_VILLE")]
			public string ADR_VILLE 
			{
				get 
				{
					return this.p_ADR_VILLE;
				}
				set 
				{
					this.p_ADR_VILLE = value;
				}
			}
        
			[DBField("ADR_PAYS_CODE")]
			public string ADR_PAYS_CODE 
			{
				get 
				{
					return this.p_ADR_PAYS_CODE;
				}
				set 
				{
					this.p_ADR_PAYS_CODE = value;
				}
			}
        
			[DBField("ADR_TEL")]
			public string ADR_TEL 
			{
				get 
				{
					return this.p_ADR_TEL;
				}
				set 
				{
					this.p_ADR_TEL = value;
				}
			}
        
			[DBField("ADR_DT_NAISSANCE",SqlDbType.DateTime)]
			public System.DateTime ADR_DT_NAISSANCE 
			{
				get 
				{
					return this.p_ADR_DT_NAISSANCE;
				}
				set 
				{
					this.p_ADR_DT_NAISSANCE = value;
				}
			}
		}
}
