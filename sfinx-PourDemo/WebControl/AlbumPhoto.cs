using System;
using System.Data;
using SableFin.SfinX.SimplePersistance;

namespace SableFin.Web.PhotoAlbum
{
    
    
		// Persistable classes for the ALBUMSPHOTO table.
		[PersistConnectionString(SessionVariable="cnxstr")]
		[PersistDynamicSQL("ALBUMSPHOTO")]
		[Serializable]
		public class Album 
		{
        
			private System.Guid p_id=Guid.NewGuid();
        
			private string p_titre="";
        
			private System.DateTime p_datedebut=DateTime.Now;
        
			private System.DateTime p_datefin=DateTime.Now;
        
			private bool p_securiser=false;
        
			private string p_role="";
        
			private bool p_multipage=false;
        
			private bool p_cartelocalisation=false;
        
			private string p_urlprefixe="";

			private System.Guid p_firstphotoid;
        
			public bool firstphotoidISNULL = true;

            private bool p_photointop;

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
        
			[DBField("datedebut",SqlDbType.DateTime)]
			public System.DateTime DateDebut 
			{
				get 
				{
					return this.p_datedebut;
				}
				set 
				{
					this.p_datedebut = value;
				}
			}
        
			[DBField("datefin",SqlDbType.DateTime)]
			public System.DateTime DateFin 
			{
				get 
				{
					return this.p_datefin;
				}
				set 
				{
					this.p_datefin = value;
				}
			}
        
			[DBField("securiser",SqlDbType.Bit)]
			public bool Secured
			{
				get 
				{
					return this.p_securiser;
				}
				set 
				{
					this.p_securiser = value;
				}
			}
        
			[DBField("role")]
			public string Roles
			{
				get 
				{
					return this.p_role;
				}
				set 
				{
					this.p_role = value;
				}
			}
        
			[DBField("multipage",SqlDbType.Bit)]
			public bool IsMultiPage
			{
				get 
				{
					return this.p_multipage;
				}
				set 
				{
					this.p_multipage = value;
				}
			}
        
			[DBField("cartelocalisation",SqlDbType.Bit)]
			public bool CarteLocalisation 
			{
				get 
				{
					return this.p_cartelocalisation;
				}
				set 
				{
					this.p_cartelocalisation = value;
				}
			}
        
			[DBField("urlprefixe")]
			public string UrlPrefixe
			{
				get 
				{
					return this.p_urlprefixe;
				}
				set 
				{
					this.p_urlprefixe = value;
				}
			}

			[DBField("firstphotoid",SqlDbType.UniqueIdentifier, IsNullable=true)]
			public System.Guid firstphotoid 
			{
				get 
				{
					return this.p_firstphotoid;
				}
				set 
				{
					this.p_firstphotoid = value;
					this.firstphotoidISNULL = false;
				}
			}

			[DBField("photointop",SqlDbType.Bit)]
			public bool photointop 
			{
				get 
				{
					return this.p_photointop;
				}
				set 
				{
					this.p_photointop = value;
				}
			}

		}
}
