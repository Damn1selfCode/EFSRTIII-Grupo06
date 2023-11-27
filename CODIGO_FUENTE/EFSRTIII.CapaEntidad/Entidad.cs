using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

	public class VentaCab
	{
		public int IdVenta { get; set; }
		public Usuario Vendedor { get; set; }
		public Cliente Cliente { get; set; }
		public DateTime FechaVenta{ get; set; }
		public decimal TotalVenta { get; set; }
	}
	public class VentaProducto
	{
		public int IdVenta { get; set; }
		public Producto Producto { get; set; }
		public int cantidad { get; set; }
		public decimal PrecioUni { get; set; }
		public decimal SubTotal { get; set; }
	}

	public class VentaServicio
	{
		public int IdVenta { get; set; }
		public Servicio Servicio{ get; set; }
		public int cantidad { get; set; }
		public decimal PrecioUni { get; set; }
		public decimal SubTotal { get; set; }
    }
	public class Usuario
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public int idTipoUsuario { get; set; }
        public string clave { get; set; }
    }
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