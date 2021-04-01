using System;
using SableFin.SfinX.SimplePersistance;


namespace Sablefin.SFINx.SimplePersistanceTest
{
	// Persistable classes for the T_TESTIDENTITY table.
	[PersistConnectionString(AppSettingsName="cnxstr")]
	[PersistStoredProc("spS_T_TESTIDENTITY", INSERTStoredProc="spI_T_TESTIDENTITY", DELETEStoredProc="spD_T_TESTIDENTITY", UPDATEStoredProc="spU_T_TESTIDENTITY")]
	public class ObjWithIdentityPK
	{
    
		private short p_id;
    
		private string p_nom;
    
		[DBField("id",System.Data.SqlDbType.SmallInt, PrimaryKey=true,Identity=true)]
		public short Identity 
		{
			get 
			{
				return this.p_id;
			}
			set 
			{
				this.p_id = value;
			}
		}
    
		[DBField("nom")]
		public string Nom
		{
			get 
			{
				return this.p_nom;
			}
			set 
			{
				this.p_nom = value;
			}
		}
	}

}
