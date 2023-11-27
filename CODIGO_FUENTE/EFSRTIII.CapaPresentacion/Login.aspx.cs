using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        readonly CapaLogica.UsuarioBL BL = new CapaLogica.UsuarioBL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var nombreUsuario = txtUsuario.Text;
            var contraseña = txtContraseña.Text;


            if (BL.AutenticarUsuario(nombreUsuario, contraseña))
            {
                Session["Usuario"] = nombreUsuario;
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire('Error', 'Credenciales inválidas. Inténtalo de nuevo.', 'error');", true);

            }
        }
    }
}