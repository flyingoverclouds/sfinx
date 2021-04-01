namespace SableFin.Web.PhotoAlbum
{
	using System;
	using System.Data;
	using SableFin.SfinX.SimplePersistance;
    
    
	// Persistable classes for the PHOTOS table.
	[PersistConnectionString(SessionVariable="cnxstr")]
	[PersistDynamicSQL("PHOTOS")]
	public class Photo 
	{
        
		private System.Guid p_id=Guid.NewGuid();
        
		private System.Int16 p_numero=1;

		private System.Guid p_albumid=new Guid();
        
		private System.Guid p_pageid=new Guid();
        
		private string p_title;
		
		private string p_lieu;
        
		private System.DateTime p_datephoto=System.DateTime.Now;
        
		private string p_commentaire;
        
		private string p_urlphoto;
        
		private string p_urlthumbnail;
        
		private string p_urlcarte;
        
		[DBField("id",SqlDbType.UniqueIdentifier, PrimaryKey=true)]
		public System.Guid id 
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

		[DBField("numero",SqlDbType.SmallInt)]
		public System.Int16 numero 
		{
			get 
			{
				return this.p_numero;
			}
			set 
			{
				this.p_numero = value;
			}
		}
        

		[DBField("albumid",SqlDbType.UniqueIdentifier)]
		public System.Guid albumid 
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
        
		[DBField("pageid",SqlDbType.UniqueIdentifier)]
		public System.Guid pageid 
		{
			get 
			{
				return this.p_pageid;
			}
			set 
			{
				this.p_pageid = value;
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

		[DBField("lieu")]
		public string lieu 
		{
			get 
			{
				return this.p_lieu;
			}
			set 
			{
				this.p_lieu = value;
			}
		}
        
		[DBField("datephoto",SqlDbType.SmallDateTime)]
		public System.DateTime datephoto 
		{
			get 
			{
				return this.p_datephoto;
			}
			set 
			{
				this.p_datephoto = value;
			}
		}
        
		[DBField("commentaire")]
		public string commentaire 
		{
			get 
			{
				return this.p_commentaire;
			}
			set 
			{
				this.p_commentaire = value;
			}
		}
        
		[DBField("urlphoto")]
		public string urlphoto 
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
        
		[DBField("urlthumbnail")]
		public string urlthumbnail 
		{
			get 
			{
				return this.p_urlthumbnail;
			}
			set 
			{
				this.p_urlthumbnail = value;
			}
		}
        
		[DBField("urlcarte")]
		public string urlcarte 
		{
			get 
			{
				return this.p_urlcarte;
			}
			set 
			{
				this.p_urlcarte = value;
			}
		}
	}
}
