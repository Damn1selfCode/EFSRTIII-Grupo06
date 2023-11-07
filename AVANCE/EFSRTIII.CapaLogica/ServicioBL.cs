using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaLogica
{
    public class ServicioBL
    {
        ServicioDL serDL = new ServicioDL();
        public List<Servicio> Lista()
        {
            try
            {
                return serDL.Lista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Servicio Obtener(int id)
        {
            try
            {
                return serDL.Obtener(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool nuevo(Servicio entidad)
        {
            try
            {
                if (entidad.NombreServicio == "")
                    throw new OperationCanceledException("El nombre es obligatorio");
                return serDL.nuevoServicio(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool editar(Servicio entidad)
        {
            try
            {
                var encontrado = serDL.Obtener(entidad.idServicio);
                if (encontrado.idServicio == 0)
                    throw new OperationCanceledException("Servicio No existe");
                return serDL.editarServicio(entidad);
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
                var encontrado = serDL.Obtener(id);
                if (encontrado.idServicio == 0)
                    throw new OperationCanceledException("Servicio No existe");
                return serDL.eliminarServicio(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
