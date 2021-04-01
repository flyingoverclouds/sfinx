using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace SableFin.WWW
{
	/// <summary>
	/// Description résumée de IndexPhotoButton.
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
		/// Génère ce contrôle dans le paramètre de sortie spécifié.
		/// </summary>
		/// <param name="output"> Le writer HTML vers lequel écrire </param>
		protected override void Render(HtmlTextWriter output)
		{
			base.Render(output);
		}
	}
}
