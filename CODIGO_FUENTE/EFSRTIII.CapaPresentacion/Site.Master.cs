using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class SiteMaster : MasterPage
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.CerrarSesion();
        }

        private void CerrarSesion()
        {
            Session.Clear();
            FormsAuthentication.SignOut(); 
            Response.Redirect("~/Login.aspx");
        }
    }
}