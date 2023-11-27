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
    public partial class ClienteDetalle : Page
    {
        private static int id = 0;
        ClienteBL cliBL = new ClienteBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idCliente"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["idCliente"].ToString());
                    if (id!= 0)
                    {
                        lblTitulo.Text = "Editar Cliente";
                        btnSubmit.Text = "Actualizar";
                        Cliente p = cliBL.Obtener(id);
                        txtNombreCliente.Text = p.NombreCliente;
                        txtRUC.Text = p.Ruc.ToString();
                        txtTelefono.Text = p.Telefono.ToString();
                        txtDireccion.Text = p.Direccion.ToString();
                        txtEmail.Text = p.Email.ToString();
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Cliente";
                        btnSubmit.Text = "Guardar";
                    }
                }
                else
                    Response.Redirect("~/Mantenimiento/Clientes.aspx");
            }
        }

        #region "Cliente"
        protected void btnCliente(object sender, EventArgs e)
        {
            Cliente p = new Cliente()
            {
                IdCliente = id,
                NombreCliente= txtNombreCliente.Text,
                Ruc =txtRUC.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
            };
        bool rpta;
            if (id != 0)
                rpta = cliBL.editar(p);
            else
                rpta = cliBL.nuevo(p);
            if (rpta)
                Response.Redirect("~/Mantenimiento/Clientes.aspx");
            else
                ScriptManager.RegisterStartupScript(this,
                    this.GetType(),"Script","alert('No se pudo" +
                    " realizar la operación')",true);
        }


        #endregion



    }
}