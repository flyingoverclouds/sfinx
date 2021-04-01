using System;
using System.Data;
using SableFin.SfinX.SimplePersistance;

namespace Sablefin.SFINx.SimplePersistanceTest
{
		// Persistable classes for the PKDOUBLE table.
		[PersistConnectionString(AppSettingsName="cnxstr")]
		[PersistStoredProc("spS_PKDOUBLE", INSERTStoredProc="spI_PKDOUBLE", DELETEStoredProc="spD_PKDOUBLE", UPDATEStoredProc="spU_PKDOUBLE", TableName="PKDOUBLE")]
		public class PKDouble
		{
        
			private int p_id1;
        
			private short p_id2;
        
			private string p_donnee;
        
			[DBField("id1", PrimaryKey=true)]
			public int id1 
			{
				get 
				{
					return this.p_id1;
				}
				set 
				{
					this.p_id1 = value;
				}
			}
        
			[DBField("id2", PrimaryKey=true)]
			public short id2 
			{
				get 
				{
					return this.p_id2;
				}
				set 
				{
					this.p_id2 = value;
				}
			}
        
			[DBField("donnee")]
			public string donnee 
			{
				get 
				{
					return this.p_donnee;
				}
				set 
				{
					this.p_donnee = value;
				}
			}
		}
}
