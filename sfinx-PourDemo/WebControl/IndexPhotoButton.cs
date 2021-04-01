using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace SableFin.WWW
{
	/// <summary>
	/// Description r�sum�e de IndexPhotoButton.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:IndexPhotoButton runat=server></{0}:IndexPhotoButton>")]
	public class IndexPhotoButton : System.Web.UI.WebControls.LinkButton
	{
		private string _id;
		[Bindable(true), 
			Category("Photo"), 
			DefaultValue("")] 
		public string PhotoId
		{
			get
			{
				return _id;
			}

			set
			{
				_id = value;
			}
		}


		public IndexPhotoButton():base()
		{
		}

		/// <summary> 
		/// G�n�re ce contr�le dans le param�tre de sortie sp�cifi�.
		/// </summary>
		/// <param name="output"> Le writer HTML vers lequel �crire </param>
		protected override void Render(HtmlTextWriter output)
		{
			base.Render(output);
		}
	}
}
