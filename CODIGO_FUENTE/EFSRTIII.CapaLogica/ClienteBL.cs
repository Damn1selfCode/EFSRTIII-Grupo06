using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaLogica
{
    public class ClienteBL
    {
        ClienteDL cliDL = new ClienteDL();
        public List<Cliente> Lista()
        {
            try
            {
                return cliDL.Lista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Cliente> ObtenerClienteXRuc(string ruc)
        {
            try
            {
                return cliDL.ObtenerClienteXRuc(ruc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente Obtener(int id)
        {
            try
            {
                return cliDL.Obtener(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool nuevo(Cliente entidad)
        {
            try
            {
                if (entidad.NombreCliente == "")
                    throw new OperationCanceledException("El nombre es obligatorio");
                return cliDL.nuevoCliente(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool editar(Cliente entidad)
        {
            try
            {
                var encontrado = cliDL.Obtener(entidad.IdCliente);
                if (encontrado.IdCliente == 0)
                    throw new OperationCanceledException("Cliente No existe");
                return cliDL.editarCliente(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var encontrado = cliDL.Obtener(id);
                if (encontrado.IdCliente == 0)
                    throw new OperationCanceledException("Cliente No existe");
                return cliDL.eliminarCliente(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
