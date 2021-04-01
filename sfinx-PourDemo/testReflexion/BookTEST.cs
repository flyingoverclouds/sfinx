using System;
using System.Data;
using Sablefin.SFINx.SimplePersistance;

namespace testReflexion
{

		[PersistConnectionString(AppSettingsName="cnxstr")]		// la chaine de connection est stocké dans la AppSettings du ficheir de Config
		[PersistStoredProc("spS_titles",UPDATEStoredProc="spU_titles",INSERTStoredProc="spI_titles",DELETEStoredProc="spD_titles",TableName="titles")]	// J'utilise des proc stock pour persisté mes objets
		public class TESTCLASSE
		{

			[DBField("title_id",PrimaryKey=true)]		// Une propriété peut etre persisté et etre une clé primaire
			private string p_title;

			[DBField("title")]							// je persiste une propriété
			public string title_id;
		
		
			[DBField("type")]							// je persiste un champ PUBLIC !!!!
			public string p_type;
		
			[DBField("pub_id")]	
			public string pub_id;
		
			[DBField("price",System.Data.SqlDbType.Money)]	// pour les types qui n'on pas de cast ADO par défaut, il faut préciser le type SQL
			public decimal p_price;
		
			[DBField("advance",DBFieldType=System.Data.SqlDbType.Money)]	
			public decimal p_advance;
		
			[DBField("royalty")]	
			public int p_royalty;
		
			[DBField("ytd_sales")]	
			public int p_ytd_sales;
		
			[DBField("notes")]	
			public string p_notes;
		
			[DBField("pubdate")]	
			public DateTime p_pubdate;
		}


}
