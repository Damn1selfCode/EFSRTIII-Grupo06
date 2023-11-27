using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaLogica
{
    public class UsuarioBL
    {
        UsuarioDL DL = new UsuarioDL();


        public bool AutenticarUsuario(string usuario, string clave)
        {
            try
            {
                return DL.AutenticarUsuario(usuario, clave);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
