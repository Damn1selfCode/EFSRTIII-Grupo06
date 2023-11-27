using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class CategoriaBL
    {
        CategoriaDL cateDL = new CategoriaDL();

        public List<Categoria> Lista()
        {
            try
            {
                return cateDL.Lista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class ProveedorBL
    {
        ProveedorDL proveDL = new ProveedorDL();

        public List<Proveedor> Lista()
        {
            try
            {
                return proveDL.Lista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class TipoServicioBL
    {
        TipoServicioDL servDL = new TipoServicioDL();

        public List<TipServicio> Lista()
        {
            try
            {
                return servDL.Lista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
