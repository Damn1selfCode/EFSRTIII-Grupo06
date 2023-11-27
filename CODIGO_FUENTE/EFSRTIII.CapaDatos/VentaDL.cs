using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class VentaDL
    {

        public int ProcesarVenta(VentaCab venta, List<VentaServicio> servicios,List<VentaProducto> productos)
        {
	        int rpta = 0;

            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                cn.Open();
                SqlTransaction transaction = cn.BeginTransaction();

                try
                {
	                int idUsuario;
	                using (SqlCommand cmdObtenerIdUsuario = new SqlCommand("SELECT idUsuario FROM Usuario WHERE usuario = @usuario", cn, transaction))
	                {
		                cmdObtenerIdUsuario.Parameters.AddWithValue("@usuario", venta.Vendedor.usuario);
		                idUsuario = Convert.ToInt32(cmdObtenerIdUsuario.ExecuteScalar());
	                }
                    // Insertar datos en la tabla VENTA_CAB
                    using (SqlCommand cmdVentaCab = new SqlCommand("INSERT INTO VENTA_CAB (IdVendedor, IdCliente, FechaVenta, TotalVenta) VALUES (@IdVendedor, @IdCliente, @FechaVenta, @TotalVenta); SELECT SCOPE_IDENTITY();", cn, transaction))
                    {
                        cmdVentaCab.Parameters.AddWithValue("@IdVendedor", idUsuario);
                        cmdVentaCab.Parameters.AddWithValue("@IdCliente", venta.Cliente.IdCliente);
                        cmdVentaCab.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                        cmdVentaCab.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);

                        // Obtener el IdVenta recién insertado
                        int idVenta = Convert.ToInt32(cmdVentaCab.ExecuteScalar());

                        // Insertar datos en la tabla VENTA_PRODUCTOS
                        foreach (var producto in productos)
                        {
                            using (SqlCommand cmdVentaProducto = new SqlCommand("INSERT INTO VENTA_PRODUCTOS (IdVenta, IdProducto, Cantidad, PrecioUni, SubTotal) VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUni, @SubTotal)", cn, transaction))
                            {
                                cmdVentaProducto.Parameters.AddWithValue("@IdVenta", idVenta);
                                cmdVentaProducto.Parameters.AddWithValue("@IdProducto", producto.Producto.IdProducto);
                                cmdVentaProducto.Parameters.AddWithValue("@Cantidad", producto.cantidad);
                                cmdVentaProducto.Parameters.AddWithValue("@PrecioUni", producto.PrecioUni);
                                cmdVentaProducto.Parameters.AddWithValue("@SubTotal", producto.SubTotal);

                                cmdVentaProducto.ExecuteNonQuery();
                            }
                        }

                        // Insertar datos en la tabla VENTA_SERVICIOS
                        foreach (var servicio in servicios)
                        {
                            using (SqlCommand cmdVentaServicio = new SqlCommand("INSERT INTO VENTA_SERVICIOS (IdVenta, IdServicio, Cantidad, PrecioUni, SubTotal) VALUES (@IdVenta, @IdServicio, @Cantidad, @PrecioUni, @SubTotal)", cn, transaction))
                            {
                                cmdVentaServicio.Parameters.AddWithValue("@IdVenta", idVenta);
                                cmdVentaServicio.Parameters.AddWithValue("@IdServicio", servicio.Servicio.idServicio);
                                cmdVentaServicio.Parameters.AddWithValue("@Cantidad", servicio.cantidad);
                                cmdVentaServicio.Parameters.AddWithValue("@PrecioUni", servicio.PrecioUni);
                                cmdVentaServicio.Parameters.AddWithValue("@SubTotal", servicio.SubTotal);

                                cmdVentaServicio.ExecuteNonQuery();
                            }
                        }

                        // Confirmar la transacción
                        transaction.Commit();

                        rpta = idVenta;
                    }
                }
                catch (Exception ex)
                {
                    // Ocurrió un error, hacer rollback
                    transaction.Rollback();
                    throw ex;
                }
            }

            return rpta;
        }

    }
}
