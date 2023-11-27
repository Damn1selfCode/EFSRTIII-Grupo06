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
    public class TipoServicioDL
    {
        public List<TipServicio> Lista()
        {
            List<TipServicio> lista = new List<TipServicio>();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_ListaTipoServicios()", cn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new TipServicio
                            {
                                IdTipoServicio = Convert.ToInt32(dr["IdTipoServicio"].ToString()),
                                TipoServicio = dr["TipoServicio"].ToString()
                            });
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
    }
    public class CategoriaDL
    {
        public List<Categoria> Lista()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_ListaCategorias()", cn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
                                NombreCategoria = dr["NombreCategoria"].ToString()
                            });
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
    }

    public class ProveedorDL
    {
        public List<Proveedor> Lista()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_ListaProveedores()", cn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"].ToString()),
                                NombreProveedor = dr["NombreProveedor"].ToString()
                            });
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
    }
}
