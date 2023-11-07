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
    public partial class ServicioDetalle : Page
    {
        private static int id = 0;
        TipoServicioBL tserBL = new TipoServicioBL();
        ServicioBL serBL = new ServicioBL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idServicio"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["idServicio"].ToString());
                    if (id!= 0)
                    {
                        lblTitulo.Text = "Editar Servicio";
                        btnSubmit.Text = "Actualizar";
                        Servicio p = serBL.Obtener(id);
                        txtNombreServicio.Text = p.NombreServicio;
                        txtDetalleServicio.Text = p.DetalleServicio;
                        CargaTipoServicio(p.TipoServicio.IdTipoServicio.ToString());
                        txtPrecio.Text = p.Precio.ToString();
                        //txtActivo.Text = p.Activo.ToString();
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Servicio";
                        btnSubmit.Text = "Guardar";
                        CargaTipoServicio();
                    }
                }
                else
                    Response.Redirect("~/Mantenimiento/Servicios.aspx");
            }
        }

        #region "Servicio"
        protected void btnServicio(object sender, EventArgs e)
        {
            Servicio p = new Servicio()
            {
                idServicio = id,
                NombreServicio= txtNombreServicio.Text,
                DetalleServicio= txtDetalleServicio.Text,
                TipoServicio = new TipServicio() 
                { IdTipoServicio = Convert.ToInt32(ddlTipoServicio.SelectedValue) },
                Precio = Convert.ToDecimal(txtPrecio.Text),
                Activo =true
        };
        bool rpta;
            if (id != 0)
                rpta = serBL.editar(p);
            else
                rpta = serBL.nuevo(p);
            if (rpta)
                Response.Redirect("~/Mantenimiento/Servicios.aspx");
            else
                ScriptManager.RegisterStartupScript(this,
                    this.GetType(),"Script","alert('No se pudo" +
                    " realizar la operación')",true);
        }


        #endregion


        private void CargaTipoServicio(string id = "")
        {
            List<TipServicio> lista = tserBL.Lista();
            ddlTipoServicio.DataTextField = "TipoServicio";
            ddlTipoServicio.DataValueField = "idTipoServicio";
            ddlTipoServicio.DataSource = lista;
            ddlTipoServicio.DataBind();

            if (id != "")
                ddlTipoServicio.SelectedValue = id;
        }

    }
}