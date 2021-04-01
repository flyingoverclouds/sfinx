using System;
using System.Data;
using SableFin.SfinX.SimplePersistance;

namespace SableFin.Web.PhotoAlbum
{
		// Persistable classes for the PAGESALBUM table.
		[PersistConnectionString(SessionVariable="cnxstr")]
		[PersistDynamicSQL("PAGESALBUM")]
		public class PageAlbum 
		{
        
			private System.Guid p_id=Guid.NewGuid();
        
			private System.Guid p_albumid=new Guid();
        
			private int p_num=0;
        
			private string p_titre="";
        
			private bool p_pagination=false;
        
			private short p_nbphoto=0;
        
			private string p_urlphoto="";
        
			[DBField("id",SqlDbType.UniqueIdentifier, PrimaryKey=true)]
			public System.Guid Id 
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
        
			[DBField("albumid",SqlDbType.UniqueIdentifier)]
			public System.Guid AlbumId
			{
				get 
				{
					return this.p_albumid;
				}
				set 
				{
					this.p_albumid = value;
				}
			}
        
			[DBField("num")]
			public int Numero 
			{
				get 
				{
					return this.p_num;
				}
				set 
				{
					this.p_num = value;
				}
			}
        
			[DBField("titre")]
			public string Titre 
			{
				get 
				{
					return this.p_titre;
				}
				set 
				{
					this.p_titre = value;
				}
			}
        
			[DBField("pagination",SqlDbType.Bit)]
			public bool Pagination 
			{
				get 
				{
					return this.p_pagination;
				}
				set 
				{
					this.p_pagination = value;
				}
			}
        
			[DBField("nbphoto")]
			public short NbPhoto 
			{
				get 
				{
					return this.p_nbphoto;
				}
				set 
				{
					this.p_nbphoto = value;
				}
			}
        
			private bool urlphotoISNULL=true;
			[DBField("urlphoto", IsNullable=true)]
			public string UrlPhoto 
			{
				get 
				{
					return this.p_urlphoto;
				}
				set 
				{
					this.p_urlphoto = value;
				}
			}
		}
}
