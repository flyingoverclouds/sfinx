using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using SableFin.SfinX.SimplePersistance;
using SableFin.Web.PhotoAlbum;
using System.Collections;

namespace SableFin.WWW.PhotoAlbum
{
	/// <summary>
	/// Description résumée de IndexPhotoMenu.
	/// </summary>
	[DefaultProperty("NbDisplayedProperty"), 
		ToolboxData("<{0}:IndexPhotoMenu runat=server></{0}:IndexPhotoMenu>")]
	public class IndexPhotoMenu : System.Web.UI.WebControls.WebControl, INamingContainer
	{

		[Category("Action")] 
		public event EventHandler SelectedPhotoChanged;

		private int _startNumber=0;
		[Bindable(true), Category("PhotoAlbum"), DefaultValue(0)] 
		public int StartNumber
		{
			get	{ return _startNumber;	}
			set	{ _startNumber = value; }
		}
		
		private int _nbDisplayedPhoto=10;
		[Bindable(true), Category("PhotoAlbum"), DefaultValue(500)] 
		public int NbDisplayedPhoto 
		{
			get	{ return _nbDisplayedPhoto;	}
			set	{ _nbDisplayedPhoto = value; }
		}

		private int _maxDisplayedChar=17;
		[Bindable(true), Category("PhotoAlbum"), DefaultValue(17)] 
		public int MaxDisplayedChar
		{
			get { return _maxDisplayedChar; }
			set { _maxDisplayedChar=value; }
		}

		protected Album _album=new Album();
		[Bindable(true), Category("PhotoAlbum"), DefaultValue("")] 
		public string AlbumId
		{
			get { return _album.Id.ToString(); }
			set 
			{
				_album=new Album();
				_album.Id=new Guid(value);
				//PersistDAL.Read(_album);
			}
		}

		private string _idPhoto="";
		[Bindable(false), Category("PhotoAlbum"), DefaultValue("")] 
		public string SelectedPhotoId
		{
			get { return _idPhoto; }
		}



		/// <summary>
		/// Reception du clic sur un éléments de l'index
		/// </summary>
		/// <param name="sender">linkbutton qui a emet l'évenement</param>
		/// <param name="e">parametre de l'evenement</param>
		public void IndexPhotoButtonClick(object sender, EventArgs e)
		{
			if (sender is LinkButton)
			{
				_idPhoto=(sender as IndexPhotoButton).PhotoId;
				if (SelectedPhotoChanged!=null)
					SelectedPhotoChanged(this,e);
			}
		}

		/// <summary>
		/// This member overrides Control.OnBubbleEvent.
		/// </summary>
		protected override bool OnBubbleEvent(object sender, EventArgs e)
		{
			// stop bubbling
			return true;
		}

		public void NextPage(object sender, EventArgs e)
		{
			_startNumber+=_nbDisplayedPhoto;
		}

		public void PreviousPage(object sender, EventArgs e)
		{
			_startNumber-=_nbDisplayedPhoto;
			if (_startNumber<0) _startNumber=0;
		}


		/// <summary>
		/// on crée les controle fils.
		/// </summary>
		protected override void CreateChildControls() 
		{
			base.CreateChildControls();

			PersistDAL.Read(_album);
			Photo ph=new Photo();
			ArrayList al=PersistDAL.ReadMultiple(ph,_nbDisplayedPhoto.ToString(),"albumid='" + _album.Id.ToString()+"' and numero>" + _startNumber,"numero",null);

			Button bprev=new Button();
			bprev.Text="   <<   ";
			bprev.ToolTip="Page précédente";
			bprev.Click+=new EventHandler(PreviousPage);
			if (_startNumber<=0) bprev.Enabled=false;
			Controls.Add(bprev);

			
			Button bnext=new Button();
			bnext.Text="   >>   ";
			bnext.ToolTip="Page Suivante";
			bnext.Click+=new EventHandler(NextPage);
			if (al.Count!=NbDisplayedPhoto) bnext.Enabled=false;
			Controls.Add(bnext);
			Controls.Add(new LiteralControl("<BR/>"));

			foreach(Photo p in al)
			{
				IndexPhotoButton ipb=new IndexPhotoButton();
				ipb.ToolTip=p.title;
				ipb.PhotoId=p.id.ToString();

				
				ipb.Text="";
				if (p.title.Length>_maxDisplayedChar)
				{
					ipb.Text=p.title.Substring(0,_maxDisplayedChar) +"...";
				} 
				else ipb.Text=p.title;
				ipb.Click+=new EventHandler(IndexPhotoButtonClick);
				ipb.Font.Name="Verdana";
				ipb.Font.Size=FontUnit.XSmall;
				Controls.Add(ipb);
				Controls.Add(new LiteralControl("<BR/>"));
			}

		}
		
		/// <summary>
		/// This member overrides Control.SaveViewState.
		/// </summary>
		protected override object SaveViewState()
		{
			object[] allStates = new object[]
			{
				// save inherited state
				base.SaveViewState(),
				// save our state
				_startNumber,
				_maxDisplayedChar,
				_nbDisplayedPhoto,
				_album
			};

			return allStates;
		}
		
		/// <summary>
		/// This member overrides Control.LoadViewState.
		/// </summary>
		protected override void LoadViewState(object savedState) 
		{
			object[] allStates = (object[])savedState;
			// load inherited state
			base.LoadViewState(allStates[0]); 
			// load our state
			_startNumber = (int) allStates[1];
			_maxDisplayedChar= (int) allStates[2];
			_nbDisplayedPhoto= (int) allStates[3];
			_album= (Album) allStates[4];
		}
		

		/// <summary> 
		/// Génère ce contrôle dans le paramètre de sortie spécifié.
		/// </summary>
		/// <param name="output"> Le writer HTML vers lequel écrire </param>
		protected override void Render(HtmlTextWriter output)
		{
			//output.Write(this.UniqueID);
			
			// these two call's are needed to show the control at design time
			ChildControlsCreated = false;
			EnsureChildControls();
			
			// delegate the actual rendering to baseclass
			base.Render(output); 

		}

	}
}
