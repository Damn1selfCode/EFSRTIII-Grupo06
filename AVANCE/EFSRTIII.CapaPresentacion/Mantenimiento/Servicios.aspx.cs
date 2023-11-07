using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Mantenimiento
{
    public partial class Servicios : System.Web.UI.Page
    {
    

        readonly CapaLogica.ServicioBL serBL = new CapaLogica.ServicioBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MuestraServicio();

        }

        #region "Servicio"
        private void MuestraServicio()
        {
            List<Servicio> lista = serBL.Lista();
            GVServicioMantenmiento.DataSource = lista;
            GVServicioMantenmiento.DataBind();
        }


        protected void Nuevo_Servicio(object sender, EventArgs e)
        {
            Response.Redirect("~/ServicioDetalle.aspx?idServicio=0");
        }


        protected void Editar_Servicio(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;
            Response.Redirect($"~/ServicioDetalle.aspx?idServicio={id}");

        }

        protected void Eliminar_Servicio(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;

            bool rpta = serBL.eliminar(Convert.ToInt32(id));
            if (rpta)
                MuestraServicio();

        }

        #endregion
    }
}