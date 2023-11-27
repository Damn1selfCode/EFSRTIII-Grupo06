using System;
using System.Collections.Generic;
using System.IO;
using CapaEntidad;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

public class VentaPdf
{
	public void GenerarPdf(VentaCab ventaCab, List<VentaProducto> productos, List<VentaServicio> servicios,  MemoryStream stream)
	{
		// Crear el documento PDF
		PdfWriter writer = new PdfWriter(stream);
		PdfDocument pdf = new PdfDocument(writer);
		Document document = new Document(pdf);

		document.Add(new Paragraph($"                              DETALLE DE VENTA  "));
		// Agregar información de la cabecera
		document.Add(new Paragraph($"Factura de Venta #{ventaCab.IdVenta}"));
		document.Add(new Paragraph($"Fecha de Venta: {ventaCab.FechaVenta}"));

		if (productos != null)
		{
			Table table = new Table(4).UseAllAvailableWidth();
			table.AddHeaderCell("Producto");
			table.AddHeaderCell("Cantidad");
			table.AddHeaderCell("Precio Unid.");
			table.AddHeaderCell("Subtotal");

			foreach (var detalle in productos)
			{

				table.AddCell(detalle.Producto.NombreProducto.ToString());
				table.AddCell(detalle.cantidad.ToString(""));
				table.AddCell(detalle.PrecioUni.ToString(""));
				table.AddCell(detalle.SubTotal.ToString(""));

			}

			document.Add(table);
			document.Add(new Paragraph("")); 
			document.Add(new Paragraph($""));
		}


		if (productos != null)
		{
			Table table = new Table(4).UseAllAvailableWidth();
			table.AddHeaderCell("Servicio");
			table.AddHeaderCell("Cantidad");
			table.AddHeaderCell("Precio");
			table.AddHeaderCell("SubTotal");

			foreach (var detalle in servicios)
			{
				table.AddCell(detalle.Servicio.NombreServicio.ToString());
				table.AddCell(detalle.cantidad.ToString(""));
				table.AddCell(detalle.PrecioUni.ToString(""));
				table.AddCell(detalle.SubTotal.ToString(""));

			}

			document.Add(table);
			document.Add(new Paragraph($""));
			document.Add(new Paragraph($""));
		}
		
		// Agregar total
		document.Add(new Paragraph($"Total: {ventaCab.TotalVenta.ToString("")} Nuevos Soles"));

		// Cerrar el documento
		document.Close();
	}
}