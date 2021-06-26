using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;


namespace Easy_Stock
{
    public partial class home : Page
    {
        protected List<Transaccion> lstTransacciones;
        protected List<Producto> lstProductos;
        protected List<Producto> lstProductosStock;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["transaction"] != null && Request.QueryString["transaction"].Equals("ok"))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "La transacción se realizó correctamente";
                }
                if ((Request.QueryString["devolucion"] != null && Request.QueryString["devolucion"].Equals("ok")))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Devolución realizada correctamente";
                }
                if ((Request.QueryString["cambio"] != null && Request.QueryString["cambio"].Equals("ok")))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Cambio realizado correctamente";
                }

                lstTransacciones = AdTransaccion.ObtenerTransacciones(true);
                lstProductos = AdProducto.ObtenerProductos("", true);
                lstProductosStock = AdProducto.ObtenerProductosStock();
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            List<Producto> lst= AdProducto.ObtenerProductosStock();
            ExportarPDF(lst, (Usuario)Session["usuario"], "Faltante de stock");
        }

        void ExportarPDF(List<Producto> lst, Usuario oUsuario, string tipoReporte)
        {

            Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            PdfPCell cell = new PdfPCell();
            pdfDoc.Open();

            ////agrego la imagen
            //Image imagen =Image.GetInstance("C:/Users/Simon/Desktop/Trabajo_Final/TrabajoFinal/WebApplication1/Assets/ES_Logo.png");
            //imagen.BorderWidth = 0;
            //imagen.Alignment = Element.ALIGN_CENTER;
            //pdfDoc.Add(imagen);
            //pdfDoc.Add(Chunk.NEWLINE);

            //Encanbezado
            PdfPTable tblEncabezado = new PdfPTable(1);
            tblEncabezado.WidthPercentage = 100;
            PdfPCell cellFecha = new PdfPCell(
            new Phrase("Fecha de generación: " + DateTime.Now + Environment.NewLine + Environment.NewLine));
            cellFecha.MinimumHeight = 30; cellFecha.BorderWidth = 0;
            tblEncabezado.AddCell(cellFecha);
            pdfDoc.Add(tblEncabezado);

            //usuario
            PdfPTable tblEncabezadoUsuario = new PdfPTable(1);
            tblEncabezadoUsuario.WidthPercentage = 100;
            PdfPCell cellUsuario = new PdfPCell(
            new Phrase("Generado por: " + (string.Format("{0} {1}",oUsuario.nombre,oUsuario.apellido))+ Environment.NewLine + Environment.NewLine));
            cellFecha.MinimumHeight = 30; cellUsuario.BorderWidth = 0;
            tblEncabezadoUsuario.AddCell(cellUsuario);
            pdfDoc.Add(tblEncabezadoUsuario);

            //tipo reporte
            PdfPTable tblEncabezadoTipoRepo = new PdfPTable(1);
            tblEncabezado.WidthPercentage = 100;
            PdfPCell cellTipoRepo = new PdfPCell(
            new Phrase("Tipo de reporte: " + tipoReporte + Environment.NewLine + Environment.NewLine));
            cellFecha.MinimumHeight = 30; cellTipoRepo.BorderWidth = 0;
            tblEncabezadoTipoRepo.AddCell(cellTipoRepo);
            pdfDoc.Add(tblEncabezadoTipoRepo);

            //Borde salto de linea primera
            PdfPTable border = new PdfPTable(1);
            border.WidthPercentage = 100;
            PdfPCell lineBorder = new PdfPCell(new Phrase(""));
            lineBorder.BorderWidth = 0; lineBorder.BorderWidthBottom = 1;
            border.AddCell(lineBorder);
            pdfDoc.Add(border);

            Paragraph textEncabezado = new Paragraph("DATOS DE LOS PRODUCTOS");
            pdfDoc.Add(textEncabezado);
            pdfDoc.Add(Chunk.NEWLINE);
            PdfPTable tblDatoPersonal = new PdfPTable(3);
            tblDatoPersonal.WidthPercentage = 100;


            //Cargar tabla
            PdfPCell cellCabecera = null;
            BaseColor bgColorCabecera = new BaseColor(115, 115, 115);
            Font fuenteCabecera = new Font(Font.FontFamily.HELVETICA, 11f, 1, new BaseColor(255, 255, 255));
            PdfPTable tblDatoProductos = new PdfPTable(5);
            tblDatoProductos.WidthPercentage = 95;

            cellCabecera = new PdfPCell(new Phrase("Producto", fuenteCabecera));
            cellCabecera.BackgroundColor = bgColorCabecera;
            cellCabecera.BorderWidth = 0;
            cellCabecera.MinimumHeight = 30;
            cellCabecera.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblDatoProductos.AddCell(cellCabecera);

            cellCabecera = new PdfPCell(new Phrase("Categoria", fuenteCabecera));
            cellCabecera.BackgroundColor = bgColorCabecera;
            cellCabecera.BorderWidth = 0;
            cellCabecera.MinimumHeight = 30;
            cellCabecera.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblDatoProductos.AddCell(cellCabecera);

            cellCabecera = new PdfPCell(new Phrase("Cantidad restante", fuenteCabecera));
            cellCabecera.BackgroundColor = bgColorCabecera;
            cellCabecera.BorderWidth = 0;
            cellCabecera.MinimumHeight = 30;
            cellCabecera.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblDatoProductos.AddCell(cellCabecera);

            cellCabecera = new PdfPCell(new Phrase("Stock minimo", fuenteCabecera));
            cellCabecera.BackgroundColor = bgColorCabecera;
            cellCabecera.BorderWidth = 0;
            cellCabecera.MinimumHeight = 30;
            cellCabecera.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblDatoProductos.AddCell(cellCabecera);

            cellCabecera = new PdfPCell(new Phrase("Stock máximo", fuenteCabecera));
            cellCabecera.BackgroundColor = bgColorCabecera;
            cellCabecera.BorderWidth = 0;
            cellCabecera.MinimumHeight = 30;
            cellCabecera.VerticalAlignment = Element.ALIGN_MIDDLE;
            tblDatoProductos.AddCell(cellCabecera);

            int contRegistros = 0; //para ir alternando el color de cada registro en la tabla
            PdfPCell cellProductos = new PdfPCell();
            BaseColor bgColorCell = new BaseColor(220, 220, 220);//Gris
            foreach (var item in lst)
            {
                //nombre
                
                cellProductos = new PdfPCell(new Phrase(item.nombre));
                if (contRegistros % 2 != 0) cellProductos.BackgroundColor = bgColorCell;
                cellProductos.BorderWidth = 0;
                cellProductos.MinimumHeight = 30;
                cellProductos.VerticalAlignment = Element.ALIGN_MIDDLE;
                tblDatoProductos.AddCell(cellProductos);

                //categoria
                cellProductos = new PdfPCell(new Phrase(item.categoria.nombre));
                if (contRegistros % 2 != 0) cellProductos.BackgroundColor = bgColorCell;
                cellProductos.BorderWidth = 0;
                cellProductos.MinimumHeight = 30;
                cellProductos.VerticalAlignment = Element.ALIGN_MIDDLE;
                tblDatoProductos.AddCell(cellProductos);

                //cant restante
                cellProductos = new PdfPCell(new Phrase(item.cantidadRestante.ToString()));
                if (contRegistros % 2 != 0) cellProductos.BackgroundColor = bgColorCell;
                cellProductos.BorderWidth = 0;
                cellProductos.MinimumHeight = 30;
                cellProductos.VerticalAlignment = Element.ALIGN_MIDDLE;
                tblDatoProductos.AddCell(cellProductos);

                //stock minimo
                cellProductos = new PdfPCell(new Phrase(item.stockMinimo.ToString()));
                if (contRegistros % 2 != 0) cellProductos.BackgroundColor = bgColorCell;
                cellProductos.BorderWidth = 0;
                cellProductos.MinimumHeight = 30;
                cellProductos.VerticalAlignment = Element.ALIGN_MIDDLE;
                tblDatoProductos.AddCell(cellProductos);

                //stock maximo
                cellProductos = new PdfPCell(new Phrase(item.stockMaximo.ToString()));
                if (contRegistros % 2 != 0) cellProductos.BackgroundColor = bgColorCell;
                cellProductos.BorderWidth = 0;
                cellProductos.MinimumHeight = 30;
                cellProductos.VerticalAlignment = Element.ALIGN_MIDDLE;
                tblDatoProductos.AddCell(cellProductos);

                contRegistros++;

            }

            pdfDoc.Add(tblDatoProductos);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Reporte.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.End();
        }
    }
}