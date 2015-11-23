using System;
using SableFin.SfinX.SimplePersistance;
using System.Collections;

namespace Sablefin.SFINx.SimplePersistanceTest
{
	/// <summary>
	/// Description résumée de Publisher.
	/// </summary>
	[PersistConnectionString(AppSettingsName="cnxstr")]		// la chaine de connection est stocké dans la AppSettings du ficheir de Config
	[PersistStoredProc("spS_publishers",UPDATEStoredProc="spU_publishers",INSERTStoredProc="spI_publishers",DELETEStoredProc="spD_publishers",TableName="publishers")]	// J'utilise des proc stock pour persisté mes objets
	public class Publisher
	{
		[DBField("pub_id",PrimaryKey=true)]
		public string pub_id="";

		[DBField("pub_name")]
		public string pub_name="";

		[DBField("city")]
		public string city="";

		[DBField("state")]
		public string state="";

		[DBField("country")]
		public string country="";

		// on prend le pub_id de cette instance et on charge tous les books qui ont le pub_id a cette valeur
		//[Aggregate("pub_id:pub_id",AggregateSELECTStoredProc="spS_titles__pub_id")]
		//public ArrayList Books=new ArrayList();
	}
}
