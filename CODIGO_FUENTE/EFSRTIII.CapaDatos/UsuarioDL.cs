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
    public class UsuarioDL
    {

        public bool AutenticarUsuario(string usu , string pwd)
        {
            bool rpta = false;
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("pa_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usu);
                cmd.Parameters.AddWithValue("@clave", pwd);
                try
                {
                    cn.Open();
                    object result = cmd.ExecuteScalar();

                    // Verificar el valor devuelto
                    if (result != null && result.ToString() == "OK")
                    {
                        rpta = true;
                    }

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
