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
    public class ServicioDL
    {
        public List<Servicio> Lista()
        {
            List<Servicio> lista = new List<Servicio>();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_ListaServicio()", cn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Servicio p = new Servicio();
                            p.idServicio = Convert.ToInt32(dr["idServicio"].ToString());
                            p.NombreServicio = dr["NombreServicio"].ToString();
                            p.DetalleServicio = dr["DetalleServicio"].ToString();
                            p.TipoServicio = new TipServicio
                            {
                                IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"].ToString()),
                                TipoServicio = dr["TipoServicio"].ToString()
                            };

                            p.Precio = (decimal)dr["Precio"];
                            p.Activo = Convert.ToBoolean(dr["Activo"].ToString());


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

        public Servicio Obtener(int id)
        {
            Servicio servicio = new Servicio();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_Servicio(@idServicio)", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idServicio", id);
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            servicio.idServicio = Convert.ToInt32(dr["idServicio"].ToString());
                            servicio.NombreServicio = dr["NombreServicio"].ToString();
                            servicio.DetalleServicio = dr["DetalleServicio"].ToString();
                            servicio.TipoServicio = new TipServicio
                            {
                                IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"].ToString()),
                                TipoServicio = dr["TipoServicio"].ToString()
                            };

                            servicio.Precio = (decimal)dr["Precio"];
                            servicio.Activo = Convert.ToBoolean(dr["Activo"].ToString());
                        }
                    }
                    return servicio;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Servicio> ObtenerServiciosXNombre(string nombre)
        {
	        List<Servicio> itemEncontrados = new List<Servicio>();

	        using (SqlConnection cn = new SqlConnection(Conexion.cadena))
	        {
		        SqlCommand cmd = new SqlCommand("select * from fn_ServicioXNombre(@nombre)", cn);
		        cmd.CommandType = CommandType.Text;
		        cmd.Parameters.AddWithValue("@nombre", nombre);
		        try
		        {
			        cn.Open();

			        using (SqlDataReader dr = cmd.ExecuteReader())
			        {
				        while (dr.Read())
				        {
					        Servicio item = new Servicio
                            {
						        idServicio = Convert.ToInt32(dr["idServicio"].ToString()),
						        NombreServicio = dr["NombreServicio"].ToString(),
                                DetalleServicio = dr["DetalleServicio"].ToString(),
						        Precio = Convert.ToDecimal(dr["Precio"])
					        };


					        TipServicio ts = new TipServicio()
					        {
						        IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"].ToString()),
						        TipoServicio = dr["TipoServicio"].ToString()
					        };

					        item.TipoServicio = ts;

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
        public bool nuevoServicio(Servicio entidad)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_nuevoServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomser", entidad.NombreServicio);
                cmd.Parameters.AddWithValue("@detser", entidad.DetalleServicio);
                cmd.Parameters.AddWithValue("@idtser", entidad.TipoServicio.IdTipoServicio);
                cmd.Parameters.AddWithValue("@precio", entidad.Precio);
                cmd.Parameters.AddWithValue("@activo", entidad.Activo);
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

        public bool editarServicio(Servicio entidad)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_modificaServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idser", entidad.idServicio);
                cmd.Parameters.AddWithValue("@nomser", entidad.NombreServicio);
                cmd.Parameters.AddWithValue("@detser", entidad.DetalleServicio);
                cmd.Parameters.AddWithValue("@idtser", entidad.TipoServicio.IdTipoServicio);
                cmd.Parameters.AddWithValue("@precio", entidad.Precio);
                cmd.Parameters.AddWithValue("@activo", entidad.Activo);
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

        public bool eliminarServicio(int id)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_eliminaServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idser", id);
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
