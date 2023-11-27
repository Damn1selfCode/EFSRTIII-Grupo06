using CapaEntidad;
using CapaLogica;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using iText.Kernel.Pdf;
using iText.Layout;

namespace CapaPresentacion
{
    public partial class Venta : System.Web.UI.Page
    {
	    private ClienteBL cliBL = new ClienteBL();
	    private ProductoBL proBL = new ProductoBL();
	    private ServicioBL serBL = new ServicioBL();
	    private VentaBL venBL = new VentaBL();
        protected void Page_Load(object sender, EventArgs e)
        {
	        if (!IsPostBack)
	        {
		        // Este código se ejecutará solo en la carga inicial de la página, no en postbacks.
		        // Puedes realizar acciones específicas de la carga inicial aquí.
		        Session["Detalles"] = null;
		        Session["Cliente"] = null;
	        }
	        else
	        {
		        // Este código se ejecutará solo en postbacks, no en la carga inicial de la página.
		        // Puedes realizar acciones específicas de postback aquí.
	        }
          
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e) {
             var ruc = txtBuscarCliente.Text;
            List<Cliente> clientesEncontrados = cliBL.ObtenerClienteXRuc(ruc);

            gvClientes.DataSource = clientesEncontrados;
        
            gvClientes.DataBind();
            updateClientePanel.Update();

        } 
        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                foreach (GridViewRow gvRow in gvClientes.Rows)
                {
                    int idCliente = Convert.ToInt32(gvClientes.DataKeys[gvRow.RowIndex]?.Value);
                    gvRow.Visible = (idCliente == rowIndex);

                    if (gvRow.RowType == DataControlRowType.DataRow)
                    {
                        LinkButton lnkSelect = (LinkButton)gvRow.FindControl("lnkSelect");

                        if (lnkSelect != null)
                        {
                            lnkSelect.Text = "Seleccionado";
                            Session["Cliente"] = rowIndex;
                        }
                    }
                }
                updateClientePanel.Update();
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           var busqueda = txtBuscar.Text;

	        if (rbProducto.Checked)
	        {
		        List<Producto> productosEncontrados = proBL.ObtenerProductosXNombre(busqueda);
		        GvProducto.DataSource = productosEncontrados;
		        GvProducto.DataBind();
		        GvServicio.DataSource = null;
		        GvServicio.DataBind();
            }
	        else
	        {
		        List<Servicio> serviciosEncontrados = serBL.ObtenerServiciosXNombre(busqueda);
		        GvServicio.DataSource = serviciosEncontrados;
		        GvServicio.DataBind();
		        GvProducto.DataSource = null;
		        GvProducto.DataBind();
            }
            

	    

	       
	        updateProductoPanel.Update();

        }
        protected void GvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
	        {
		        try
		        {
                    var cantidad = Convert.ToDouble(txtCantidad.Text);

                    GridViewRow selectedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;

                    var codigo = GvProducto.DataKeys[selectedRow.RowIndex]["IdProducto"];
                    var descripcion = selectedRow.Cells[0].Text;  
                    var precio = selectedRow.Cells[3].Text; //"Precio"
                    var Tipo = "Producto";

                    DataTable dtDetalles;
                    if (gvDetalles.Rows.Count > 0)
                    {
	                    dtDetalles = (DataTable)Session["Detalles"];
                    }
                    else
                    {
                        dtDetalles = new DataTable();
                        dtDetalles.Columns.Add("Codigo", typeof(int));
                        dtDetalles.Columns.Add("Tipo", typeof(string));
                        dtDetalles.Columns.Add("Cantidad", typeof(double));
                        dtDetalles.Columns.Add("Descripcion", typeof(string));
                        dtDetalles.Columns.Add("Precio", typeof(double));
                        dtDetalles.Columns.Add("SubTotal", typeof(double));
                    }

                    DataRow existingRow = null;
                    if (dtDetalles != null)
                    {
	                     existingRow = dtDetalles.Rows.Cast<DataRow>().FirstOrDefault(row =>
		                    (int)row["Codigo"] == Convert.ToInt32(codigo) && (string)row["Tipo"] == Tipo);

                    }

                    if (existingRow != null)
                    {
                        existingRow["Cantidad"] = cantidad;
						existingRow["SubTotal"] = Convert.ToDecimal(cantidad) * Convert.ToDecimal(precio);
                    }
                    else
                    {
                        DataRow newRow = dtDetalles.NewRow();
                        newRow["Codigo"] = codigo;
                        newRow["Tipo"] = Tipo;
                        newRow["Cantidad"] = cantidad;
                        newRow["Descripcion"] = descripcion;
                        newRow["Precio"] = precio;
                        newRow["SubTotal"] = Convert.ToDecimal(cantidad) * Convert.ToDecimal(precio);
                        dtDetalles.Rows.Add(newRow);
                    }

                    Session["Detalles"] = dtDetalles;
                    gvDetalles.DataSource = dtDetalles;
                    gvDetalles.DataBind();

                    GvProducto.DataSource = null;
                    GvProducto.DataBind();
                    txtCantidad.Text = "";
                    updateClientePanel.Update();
                    lblMensaje.Text = "";
		        }
		        catch (Exception a)
		        {

			        lblMensaje.Text = "Ingresar un número válido";
                }
		      
	        }

        }
	    protected void GvServicio_RowCommand(object sender, GridViewCommandEventArgs e)
	    {

            if (e.CommandName == "Select")
            {
                try
                {
                    var cantidad = Convert.ToDouble(txtCantidad.Text);

                    GridViewRow selectedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;

                    var codigo = GvServicio.DataKeys[selectedRow.RowIndex]["IdServicio"];
                    var descripcion = selectedRow.Cells[0].Text;//Nombre Servicio
                    var precio = selectedRow.Cells[3].Text;//"Precio"
                    var Tipo = "Servicio";

                    DataTable dtDetalles;
                    if (gvDetalles.Rows.Count > 0)
                    {
                        dtDetalles = (DataTable)Session["Detalles"];
                    }
                    else
                    {
                        dtDetalles = new DataTable();
                        dtDetalles.Columns.Add("Codigo", typeof(int));
                        dtDetalles.Columns.Add("Tipo", typeof(string));
                        dtDetalles.Columns.Add("Cantidad", typeof(double));
                        dtDetalles.Columns.Add("Descripcion", typeof(string));
                        dtDetalles.Columns.Add("Precio", typeof(double));
                        dtDetalles.Columns.Add("SubTotal", typeof(double));
                    }
                    DataRow existingRow = null;
                    if (dtDetalles != null)
                    {
	                     existingRow = dtDetalles.Rows.Cast<DataRow>().FirstOrDefault(row =>
		                    (int)row["Codigo"] == Convert.ToInt32(codigo) && (string)row["Tipo"] == Tipo);

                    }


                    if (existingRow != null)
                    {
                        existingRow["Cantidad"] = cantidad;
                        existingRow["SubTotal"] = Convert.ToDecimal(cantidad) * Convert.ToDecimal(precio);
                    }
                    else
                    {
                        DataRow newRow = dtDetalles.NewRow();
                        newRow["Codigo"] = codigo;
                        newRow["Tipo"] = Tipo;
                        newRow["Cantidad"] = cantidad;
                        newRow["Descripcion"] = descripcion;
                        newRow["Precio"] = precio;
                        newRow["SubTotal"] = Convert.ToDecimal(cantidad) * Convert.ToDecimal(precio);
                        dtDetalles.Rows.Add(newRow);
                    }

                    Session["Detalles"] = dtDetalles;
                    gvDetalles.DataSource = dtDetalles;
                    gvDetalles.DataBind();

                    GvServicio.DataSource = null;
                    GvServicio.DataBind();
                    txtCantidad.Text = "";
                    updateClientePanel.Update();
                    lblMensaje.Text = "";
                }
                catch (Exception a)
                {

                    lblMensaje.Text = "Ingresar un número válido";
                }

            }

        }

	    protected void btnProcesarVenta_Click(object sender, EventArgs e)
	    {
		    try
		    {

                if (Session["Cliente"] == null)
			    {
				    string script = "alert('Seleccionar un Cliente.');";
				 //   ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
				    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire('Error', 'Credenciales inválidas. Inténtalo de nuevo.', 'error');", true);

					return;
	            }

			    if (Session["Detalles"] == null)
			    {
				    string script = "alert('Agregar productos y/o servicios.');";
				    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);

	                return;
			    }

			    decimal total = 0;

			    DataTable dtDetalles = (DataTable)Session["Detalles"];


			    List<VentaProducto> listaProductos = new List<VentaProducto>();
			    List<VentaServicio> listaServicios = new List<VentaServicio>();


			    foreach (DataRow row in dtDetalles.Rows)
			    {
				    
				    int idcodigo= Convert.ToInt32(row["Codigo"]);
				    int cantidad = Convert.ToInt32(row["Cantidad"]);
				    decimal precioUni = Convert.ToDecimal(row["Precio"]);
				    decimal subTotal = Convert.ToDecimal(row["SubTotal"]);
				    string tipo = Convert.ToString(row["Tipo"]);

				    total += subTotal;

	                if (tipo == "Producto")
	                {

		                Producto pro = new Producto();
		                pro.IdProducto = idcodigo;
	                    VentaProducto producto = new VentaProducto
					    {
						    Producto = pro,
						    cantidad = cantidad,
						    PrecioUni = precioUni,
						    SubTotal = subTotal
					    };
					    listaProductos.Add(producto);
				    }
				    else if (tipo == "Servicio")
	                {
		                Servicio ser = new Servicio();
		                ser.idServicio = idcodigo;
	                    VentaServicio servicio = new VentaServicio
					    {
						    Servicio = ser,
						    cantidad = cantidad,
						    PrecioUni = precioUni,
						    SubTotal = subTotal
					    };
					    listaServicios.Add(servicio);
				    }
			    }

	            Usuario u = new Usuario();
			    u.usuario = Session["Usuario"].ToString();
			    Cliente c = new Cliente();
			    c.IdCliente = Convert.ToInt32(Session["Cliente"]);

	            VentaCab v = new VentaCab();
	            v.Vendedor = u;
	            v.Cliente = c;
	            v.FechaVenta=DateTime.Now;
	            v.TotalVenta = total;

	            int idVentas= venBL.ProcesarVentas(v,listaServicios,listaProductos);

	            if (idVentas>0)
	            {
		            Session["correlativo"] = idVentas;

					LblMensajeProcesar.Text = "";
                    //GvServicio.DataSource = null;
                    //GvServicio.DataBind();
                    //gvDetalles.DataSource = null;
                    //gvDetalles.DataBind();
                    //GvProducto.DataSource = null;
                    //GvProducto.DataBind();
                    //Session["Detalles"] = null;
                    //Session["Cliente"] = null;
                    BtnBuscar.Enabled = false;
                    btnBuscarCliente.Enabled = false;
                    btnProcesarVenta.Enabled = false;
                    btnGenerarFactura.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", "Se proceso correctamente", true);
                }
	          



            }
            catch (Exception exception)
		    {
                LblMensajeProcesar.Text = "Error al procesar";
            }

        }
	    protected void btnGenerarFactura_Click(object sender, EventArgs e)
		{
			if (Session["Cliente"] == null)
			{
				string script = "alert('Seleccionar un Cliente.');";
				ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);

				return;
			}

			if (Session["Detalles"] == null)
			{
				string script = "alert('Agregar productos y/o servicios.');";
				ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);

				return;
			}

			int correlativo =Convert.ToInt32(Session["correlativo"]);

			decimal total = 0;

			DataTable dtDetalles = (DataTable)Session["Detalles"];


			List<VentaProducto> listaProductos = new List<VentaProducto>();
			List<VentaServicio> listaServicios = new List<VentaServicio>();


			foreach (DataRow row in dtDetalles.Rows)
			{

				int idcodigo = Convert.ToInt32(row["Codigo"]);
				int cantidad = Convert.ToInt32(row["Cantidad"]);
				string descripcion =Convert.ToString(row["Descripcion"]);
				decimal precioUni = Convert.ToDecimal(row["Precio"]);
				decimal subTotal = Convert.ToDecimal(row["SubTotal"]);
				string tipo = Convert.ToString(row["Tipo"]);

				total += subTotal;

				if (tipo == "Producto")
				{

					Producto pro = new Producto();
					pro.IdProducto = idcodigo;
					pro.NombreProducto = descripcion;
					VentaProducto producto = new VentaProducto
					{
						Producto = pro,
						cantidad = cantidad,
						PrecioUni = precioUni,
						SubTotal = subTotal
					};
					listaProductos.Add(producto);
				}
				else if (tipo == "Servicio")
				{
					Servicio ser = new Servicio();
					ser.idServicio = idcodigo;
					ser.NombreServicio = descripcion;
					VentaServicio servicio = new VentaServicio
					{
						Servicio = ser,
						cantidad = cantidad,
						PrecioUni = precioUni,
						SubTotal = subTotal
					};
					listaServicios.Add(servicio);
				}
			}

			Usuario u = new Usuario();
			u.usuario = Session["Usuario"].ToString();

			Cliente c = new Cliente();
			c.IdCliente = Convert.ToInt32(Session["Cliente"]);

			VentaCab v = new VentaCab();
			v.IdVenta = correlativo;
			v.Vendedor = u;
			v.Cliente = c;
			v.FechaVenta = DateTime.Now;
			v.TotalVenta = total;



		    // Crear un documento PDF
		    using (MemoryStream stream = new MemoryStream())
		    {
			    VentaPdf ventaPdf = new VentaPdf();
			    ventaPdf.GenerarPdf(v, listaProductos, listaServicios, stream);

			    string rutaArchivo = Server.MapPath("~/App_Data/Factura"+ correlativo + ".pdf");
			    File.WriteAllBytes(rutaArchivo, stream.ToArray());

			    Response.Clear();
			    Response.ContentType = "application/pdf";
			    Response.AddHeader("Content-Disposition", "attachment;filename=Factura"+ correlativo + ".pdf");
			    Response.Cache.SetCacheability(HttpCacheability.NoCache);

			    using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open))
			    {
				    byte[] buffer = new byte[fs.Length];
				    fs.Read(buffer, 0, buffer.Length);
				    Response.BinaryWrite(buffer);
			    }

			    Response.Flush();
			    HttpContext.Current.ApplicationInstance.CompleteRequest();

			}

		}

    }
}	