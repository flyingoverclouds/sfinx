using System;
using System.Data;
using SableFin.SfinX.SimplePersistance;

namespace Sablefin.SFINx.SimplePersistanceTest
{
	//[PersistStoredProc("spS_titles", INSERTStoredProc="spI_titles", DELETEStoredProc="spD_titles", UPDATEStoredProc="spU_titles", TableName="titles")]
	[PersistConnectionString(AppSettingsName="cnxstrsqlMAISON")]
	//[PersistConnectionString(AppSettingsName="cnxstrsql")]
	//[PersistConnectionString()]
	//[PersistConnectionString(AppSettingsName="cnxstroledb")]
	[PersistDynamicSQL("titles")]
	public class titles 
	{
    
		private string p_title_id;
    
		private string p_title;
    
		private string p_type;
    
		private string p_pub_id;
    
		public bool pub_idISNULL=true;
    
		private System.Decimal p_price;
    
		public bool priceISNULL=true;
    
		private System.Decimal p_advance;
    
		public bool advanceISNULL=true;
    
		private int p_royalty;
    
		public bool royaltyISNULL=true;
    
		private int p_ytd_sales;
    
		public bool ytd_salesISNULL=true;
    
		private string p_notes;
    
		public bool notesISNULL=true;
    
		private System.DateTime p_pubdate;
    
		[DBField("title_id", PrimaryKey=true)]
		public string title_id 
		{
			get 
			{
				return this.p_title_id;
			}
			set 
			{
				this.p_title_id = value;
			}
		}
    
		[DBField("title")]
		public string title 
		{
			get 
			{
				return this.p_title;
			}
			set 
			{
				this.p_title = value;
			}
		}
    
		[DBField("type")]
		public string type 
		{
			get 
			{
				return this.p_type;
			}
			set 
			{
				this.p_type = value;
			}
		}
    
		[DBField("pub_id", IsNullable=true)]
		public string pub_id 
		{
			get 
			{
				return this.p_pub_id;
			}
			set 
			{
				this.p_pub_id = value;
				this.pub_idISNULL = false;
			}
		}
    
		[DBField("price",SqlDbType.Money, IsNullable=true)]
		public System.Decimal price 
		{
			get 
			{
				return this.p_price;
			}
			set 
			{
				this.p_price = value;
				this.priceISNULL = false;
			}
		}
    
		[DBField("advance",SqlDbType.Money, IsNullable=true)]
		public System.Decimal advance 
		{
			get 
			{
				return this.p_advance;
			}
			set 
			{
				this.p_advance = value;
				this.advanceISNULL = false;
			}
		}
    
		[DBField("royalty", IsNullable=true)]
		public int royalty 
		{
			get 
			{
				return this.p_royalty;
			}
			set 
			{
				this.p_royalty = value;
				this.royaltyISNULL = false;
			}
		}
    

		[DBField("ytd_sales", IsNullable=true)]
		public int ytd_sales 
		{
			get 
			{
				return this.p_ytd_sales;
			}
			set 
			{
				this.p_ytd_sales = value;
				this.ytd_salesISNULL = false;
			}
		}
    

		[DBField("notes", IsNullable=true)]
		public string notes 
		{
			get 
			{
				return this.p_notes;
			}
			set 
			{
				this.p_notes = value;
				this.notesISNULL = false;
			}
		}
    
		[DBField("pubdate",SqlDbType.DateTime)]
		public System.DateTime pubdate 
		{
			get 
			{
				return this.p_pubdate;
			}
			set 
			{
				this.p_pubdate = value;
			}
		}
	}
}
