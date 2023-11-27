using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Mantenimiento
{
    public partial class Productos : System.Web.UI.Page
    {
        readonly CapaLogica.ProductoBL proBL = new CapaLogica.ProductoBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MuestraProducto();

        }

        #region "PRODUCTO"
        private void MuestraProducto()
        {
            List<Producto> lista = proBL.Lista();
            GVProducto.DataSource = lista;
            GVProducto.DataBind();
        }


        protected void Nuevo_Producto(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/ProductoDetalle.aspx?idProducto=0");
        }


        protected void Editar_Producto(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;
            Response.Redirect($"~/Mantenimiento/ProductoDetalle.aspx?idProducto={id}");

        }

        protected void Eliminar_Producto(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;

            bool rpta = proBL.eliminar(Convert.ToInt32(id));
            if (rpta)
                MuestraProducto();

        }
        #endregion
    }
}