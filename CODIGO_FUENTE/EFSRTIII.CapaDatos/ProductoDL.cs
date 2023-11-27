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
    public class ProductoDL
    {
        public List<Producto> Lista()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_ListaProducto()", cn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Producto p = new Producto();
                            p.IdProducto = Convert.ToInt32(dr["IDProducto"].ToString());
                            p.NombreProducto = dr["NombreProducto"].ToString();
                            p.Proveedor = new Proveedor
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"].ToString()),
                                NombreProveedor = dr["NombreProveedor"].ToString()
                            };

                            p.Categoria = new Categoria
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
                                NombreCategoria = dr["NombreCategoria"].ToString()
                            };

                            p.Precio = (decimal)dr["Precio"];
                            p.stock = Convert.ToInt32(dr["Stock"].ToString());


                            lista.Add(p);

                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<Producto> ObtenerProductosXNombre(string nombre)
        {
	        List<Producto> itemEncontrados = new List<Producto>();

	        using (SqlConnection cn = new SqlConnection(Conexion.cadena))
	        {
		        SqlCommand cmd = new SqlCommand("select * from fn_ProductoXNombre(@nombre)", cn);
		        cmd.CommandType = CommandType.Text;
		        cmd.Parameters.AddWithValue("@nombre", nombre);
		        try
		        {
			        cn.Open();

			        using (SqlDataReader dr = cmd.ExecuteReader())
			        {
				        while (dr.Read())
				        {
					        Producto item = new Producto
                            {
	                            IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
	                            NombreProducto = dr["NombreProducto"].ToString(),
	                            Precio = Convert.ToDecimal(dr["Precio"])
					        };

					        Categoria cat = new Categoria()
					        {
						        IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
						        NombreCategoria = dr["NombreCategoria"].ToString()
					        };

					        Proveedor prov = new Proveedor()
					        {
						        IdProveedor = Convert.ToInt32(dr["IdProveedor"].ToString()),
						        NombreProveedor = dr["NombreProveedor"].ToString()
					        };

                            item.Categoria = cat;
                            item.Proveedor = prov;

                            itemEncontrados.Add(item);
				        }
			        }
			        return itemEncontrados;
		        }
		        catch (Exception ex)
		        {
			        throw ex;
		        }
	        }
        }
        public Producto Obtener(int id)
        {
            Producto entidad = new Producto();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_Producto(@idProducto)", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idProducto", id);
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad.IdProducto = Convert.ToInt32(dr["IDProducto"].ToString());
                            entidad.NombreProducto = dr["NombreProducto"].ToString();
                            entidad.Proveedor = new Proveedor
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"].ToString()),
                                NombreProveedor = dr["NombreProveedor"].ToString()
                            };

                            entidad.Categoria = new Categoria
                                {
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
                                    NombreCategoria = dr["NombreCategoria"].ToString()
                                };

                            entidad.Precio = (decimal)dr["Precio"];
                            entidad.stock = Convert.ToInt32(dr["Stock"].ToString());
                        }
                    }
                    return entidad;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public bool nuevoProducto(Producto entidad)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_nuevoProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", entidad.NombreProducto);
                cmd.Parameters.AddWithValue("@idpro", entidad.Proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@idcat", entidad.Categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@precio", entidad.Precio);
                cmd.Parameters.AddWithValue("@stock", entidad.stock);
                try
                {
                    cn.Open();
                    int filasafectadas = cmd.ExecuteNonQuery();
                    if (filasafectadas > 0) rpta = true;
                    return rpta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool editarProducto(Producto entidad)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_modificaProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idprod", entidad.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", entidad.NombreProducto);
                cmd.Parameters.AddWithValue("@idpro", entidad.Proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@idcat", entidad.Categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@precio", entidad.Precio);
                cmd.Parameters.AddWithValue("@stock", entidad.stock);
                try
                {
                    cn.Open();
                    int filasafectadas = cmd.ExecuteNonQuery();
                    if (filasafectadas > 0) rpta = true;
                    return rpta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool eliminarProducto(int id)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_eliminaProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", id);
                try
                {
                    cn.Open();
                    int filasafectadas = cmd.ExecuteNonQuery();
                    if (filasafectadas > 0) rpta = true;
                    return rpta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
