using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente{ get; set; }
        public string Ruc { get; set; }
        public string Telefono{ get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public Proveedor Proveedor { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
        public int stock { get; set; }
	}
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
    }

    public class Categoria
    {
        public int IdCategoria  { get; set; }
        public string NombreCategoria { get; set; }
    }


    public class Servicio
    {
        public int idServicio { get; set; }
        public string NombreServicio { get; set; }
        public string DetalleServicio { get; set; }
        public TipServicio TipoServicio { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
    }
    public class TipServicio
    {
        public int IdTipoServicio { get; set; }
        public string TipoServicio { get; set; }
    }
}