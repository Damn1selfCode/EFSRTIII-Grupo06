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
    public class ClienteDL
    {
        public List<Cliente> Lista()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_ListaCliente()", cn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cliente p = new Cliente();
                            p.IdCliente = Convert.ToInt32(dr["IdCliente"].ToString());
                            p.NombreCliente = dr["NombreCliente"].ToString();
                            p.Ruc = dr["Ruc"].ToString();
                            p.Telefono = dr["Telefono"].ToString();
                            p.Direccion = dr["Direccion"].ToString();
                            p.Email = dr["email"].ToString();

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

        public Cliente Obtener(int id)
        {
            Cliente entidad = new Cliente();
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_Cliente(@IdCliente)", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idCliente", id);
                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad.IdCliente = Convert.ToInt32(dr["IdCliente"].ToString());
                            entidad.NombreCliente = dr["NombreCliente"].ToString();
                            entidad.Ruc = dr["Ruc"].ToString();
                            entidad.Telefono = dr["Telefono"].ToString();
                            entidad.Direccion = dr["Direccion"].ToString();
                            entidad.Email = dr["email"].ToString();
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


        public bool nuevoCliente(Cliente entidad)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_nuevoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom", entidad.NombreCliente);
                cmd.Parameters.AddWithValue("@ruc", entidad.Ruc);
                cmd.Parameters.AddWithValue("@tel", entidad.Telefono);
                cmd.Parameters.AddWithValue("@dir", entidad.Direccion);
                cmd.Parameters.AddWithValue("@ema", entidad.Email);
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

        public bool editarCliente(Cliente entidad)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_modificaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", entidad.IdCliente);
                cmd.Parameters.AddWithValue("@nom", entidad.NombreCliente);
                cmd.Parameters.AddWithValue("@ruc", entidad.Ruc);
                cmd.Parameters.AddWithValue("@tel", entidad.Telefono);
                cmd.Parameters.AddWithValue("@dir", entidad.Direccion);
                cmd.Parameters.AddWithValue("@ema", entidad.Email);
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

        public bool eliminarCliente(int id)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_eliminaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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
