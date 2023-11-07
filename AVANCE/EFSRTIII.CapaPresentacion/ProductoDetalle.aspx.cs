using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using System.Globalization;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class ProductoDetalle : Page
    {
        private static int id = 0;
        ProveedorBL proBL = new ProveedorBL();
        CategoriaBL cateBL = new CategoriaBL();
        ProductoBL prodBL = new ProductoBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idProducto"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["idProducto"].ToString());
                    if (id!= 0)
                    {
                        lblTitulo.Text = "Editar Producto";
                        btnSubmit.Text = "Actualizar";
                        Producto p = prodBL.Obtener(id);
                        txtNombreProducto.Text = p.NombreProducto;
                        CargaProveedores(p.Proveedor.IdProveedor.ToString());
                        CargaCategorias(p.Categoria.IdCategoria.ToString());
                        txtPrecio.Text = p.Precio.ToString();
                        txtStock.Text = p.stock.ToString();
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Producto";
                        btnSubmit.Text = "Guardar";
                        CargaCategorias();
                        CargaProveedores();
                    }
                }
                else
                    Response.Redirect("~/Mantenimiento/Productos.aspx");
            }
        }

        #region "Producto"
        protected void btnProducto(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                IdProducto = id,
                NombreProducto= txtNombreProducto.Text,
                Proveedor = new Proveedor() 
                { IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue) },
                Categoria = new Categoria()
                { IdCategoria = Convert.ToInt32(ddlCategoria.SelectedValue) },
                Precio = Convert.ToDecimal(txtPrecio.Text),
                stock = Convert.ToInt32(txtStock.Text)
        };
        bool rpta;
            if (id != 0)
                rpta = prodBL.editar(p);
            else
                rpta = prodBL.nuevo(p);
            if (rpta)
                Response.Redirect("~/Mantenimiento/Productos.aspx");
            else
                ScriptManager.RegisterStartupScript(this,
                    this.GetType(),"Script","alert('No se pudo" +
                    " realizar la operación')",true);
        }


        #endregion


        private void CargaProveedores(string id = "")
        {
            List<Proveedor> lista = proBL.Lista();
            ddlProveedor.DataTextField = "NombreProveedor";
            ddlProveedor.DataValueField = "IdProveedor";
            ddlProveedor.DataSource = lista;
            ddlProveedor.DataBind();

            if (id != "")
                ddlProveedor.SelectedValue = id;
        }

        private void CargaCategorias(string id = "")
        {
            List<Categoria> lista = cateBL.Lista();
            ddlCategoria.DataTextField = "NombreCategoria";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataSource = lista;
            ddlCategoria.DataBind();

            if (id != "")
                ddlProveedor.SelectedValue = id;
        }

    }
}