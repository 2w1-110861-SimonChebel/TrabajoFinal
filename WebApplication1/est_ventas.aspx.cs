using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Easy_Stock
{
    public partial class est_ventas : Page
    {
        protected List<Categoria> categorias;
        protected List<Producto> productos;
        protected ReVenta oReVentaCat;
        protected ReVenta oReVentaProd;
        protected List<Producto> lstProductosStock;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (cboCategorias.SelectedValue == "0") divMensajeNoEncontrado.Visible = false;

                oReVentaCat = AdReporte.ObtenerTotalPorCategoria();
                Session["oReVentaCat"] = oReVentaCat;

                oReVentaProd = AdReporte.ObtenerTotalPorProduto();
                Session["oReVentaProd"] = oReVentaProd;

                categorias = AdCategoria.ObtenerCategorias();
                Session["catRanking"] = categorias;

                lstProductosStock = AdProducto.ObtenerProductosStock();
                Session["proStock"] = lstProductosStock;

                CargarCombo();
            }
            else {
                if (cboCategorias.SelectedValue == "0") divMensajeNoEncontrado.Visible = false;
                if (Session["oReVentaCat"]!= null) oReVentaCat = (ReVenta)Session["oReVentaCat"];
                if(Session["catRanking"]!= null) categorias = (List<Categoria>)Session["catRanking"];
                if (Session["oReVentaProd"] != null) oReVentaProd = (ReVenta)Session["oReVentaProd"];
                if (Session["proStock"] != null) { lstProductosStock = (List<Producto>)Session["proStock"]; } else lstProductosStock = new List<Producto>();
                if (Session["TotalesCategorias"] != null && Session["ValorTotalCategoria"] != null)
                    crtVentasCategoria.Series["Series"].Points.DataBindXY((List<string>)Session["TotalesCategorias"],(List<decimal>)Session["ValorTotalCategoria"]);
            }
        }

        protected void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReVenta  oReVenta = AdReporte.ObtenerTotalPorCategoria(Convert.ToInt32(((DropDownList)sender).SelectedValue));
            if (oReVenta != null)
            {
                divMensajeNoEncontrado.Visible = false;
                Session["totalPorCategoria"] = null;
                List<string> lstTotalesCategorias = new List<string> { oReVenta.totalesCategoriasxFactura.First().categoria.nombre };
                List<decimal> lstValorTotal = new List<decimal> { oReVenta.CalcularTotalPorCategoria() };
                crtVentasCategoria.Series["Series"].Points.DataBindXY(lstTotalesCategorias, lstValorTotal);

                crtVentasCategoria.ToolTip = lstValorTotal.First().ToString();
                divGrafico.Attributes["style"] = "display:block"; 

                Session["TotalesCategorias"] = lstTotalesCategorias;
                Session["ValorTotalCategoria"] = lstValorTotal;

            }
            else {
                Session["TotalesCategorias"] = null;
                Session["ValorTotalCategoria"] = null;
                divGrafico.Attributes["style"] = "display:none";
                divMensajeNoEncontrado.Visible = true;
            }
        }

        private void CargarCombo()
        {
            cboCategorias.DataSource = null;

            foreach (var item in categorias)
            {
                cboCategorias.Items.Add(
                    new ListItem { 
                        Value = item.idCategoria.ToString(),
                        Text = item.nombre
                    }
                );
            }
        }

        protected void btnGenerarReporteStock_Click(object sender, EventArgs e)
        {
            lstProductosStock = Session["proStock"] != null ? (List<Producto>)Session["proStock"] : AdProducto.ObtenerProductosStock();
            ExportarPDF(lstProductosStock,(Usuario)Session["usuario"],"Faltante de stock");
        }

        protected void ExportarPDF(List<Producto> lst, Usuario oUsuario, string tipoReporte)
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
            new Phrase("Generado por: " + (string.Format("{0} {1}", oUsuario.nombre, oUsuario.apellido)) + Environment.NewLine + Environment.NewLine));
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