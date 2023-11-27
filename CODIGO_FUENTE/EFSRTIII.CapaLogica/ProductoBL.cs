using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaLogica
{
    public class ProductoBL
    {
        ProductoDL prodDL = new ProductoDL();
        public List<Producto> Lista()
        {
            try
            {
                return prodDL.Lista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Producto Obtener(int id)
        {
            try
            {
                return prodDL.Obtener(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Producto> ObtenerProductosXNombre(string nombre)
        {
	        try
	        {
		        return prodDL.ObtenerProductosXNombre(nombre);
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
        public bool nuevo(Producto entidad)
        {
            try
            {
                if (entidad.NombreProducto == "")
                    throw new OperationCanceledException("El nombre es obligatorio");
                return prodDL.nuevoProducto(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool editar(Producto entidad)
        {
            try
            {
                var encontrado = prodDL.Obtener(entidad.IdProducto);
                if (encontrado.IdProducto == 0)
                    throw new OperationCanceledException("Producto No existe");
                return prodDL.editarProducto(entidad);
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
                var encontrado = prodDL.Obtener(id);
                if (encontrado.IdProducto == 0)
                    throw new OperationCanceledException("Producto No existe");
                return prodDL.eliminarProducto(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
