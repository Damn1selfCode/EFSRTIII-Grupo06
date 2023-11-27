using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaLogica
{
    public class VentaBL
    {
        VentaDL DL = new VentaDL();


        public int ProcesarVentas(VentaCab venta, List<VentaServicio> servicios, List<VentaProducto> productos)
        {
            try
            {
                return DL.ProcesarVenta(venta, servicios, productos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
