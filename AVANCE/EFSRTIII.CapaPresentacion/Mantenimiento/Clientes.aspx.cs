using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Mantenimiento
{
    public partial class Clientes : System.Web.UI.Page
    {
  

            readonly CapaLogica.ClienteBL cliBL = new CapaLogica.ClienteBL();
            protected void Page_Load(object sender, EventArgs e)
            {
                MuestraCliente();

            }

            private void MuestraCliente()
            {
                List<Cliente> lista = cliBL.Lista();
                GVClienteMantenmiento.DataSource = lista;
                GVClienteMantenmiento.DataBind();
            }
        protected void Nuevo_Cliente(object sender, EventArgs e)
            {
                Response.Redirect("~/ClienteDetalle.aspx?IdCliente=0");
            }
            protected void Editar_Cliente(object sender, EventArgs e)
            {
                LinkButton btn = (LinkButton)sender;
                string id = btn.CommandArgument;
                Response.Redirect($"~/ClienteDetalle.aspx?IdCliente={id}");

            }
            protected void Eliminar_Cliente(object sender, EventArgs e)
            {
                LinkButton btn = (LinkButton)sender;
                string id = btn.CommandArgument;

                bool rpta = cliBL.eliminar(Convert.ToInt32(id));
                //if (rpta)
                //    MuestraCliente();

            }
    }
}