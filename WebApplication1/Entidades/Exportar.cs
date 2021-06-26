using System;
using System.Collections.Generic;
using System.IO;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Easy_Stock.Entidades
{
    public static class Exportar
    {
        //public static void ExportarPDF(List<Producto> lst, Usuario oUsuario, string tipoReporte)
        //{
        //    PdfWriter pw = new PdfWriter("");
        //    PdfDocument pd = new PdfDocument(pw);
        //    Document doc = new Document(pd, PageSize.LETTER);
        //    MemoryStream ms = new MemoryStream();

        //    //Encabezado
        //    doc.Add(new Paragraph(
        //        "Fecha: " + DateTime.Now + Environment.NewLine +
        //        "Operador: " + string.Format("{0} {1}",oUsuario.nombre,oUsuario.apellido) + Environment.NewLine +
        //        "Tipo de reporte: " +  tipoReporte
        //        ));

        //    foreach (var item in lst)
        //    {
        //        doc.Add(new Paragraph(
        //            "Producto: " + item.nombre + "Marca: "+item.marca + "Cantidad Restante: "+item.cantidadRestante+
        //            "Stock Mínimo: "
        //        ));
        //    }
        //    doc.Close();

        //    byte[] byteStream = ms.ToArray();
        //    ms = new MemoryStream();
        //    ms.Write(byteStream, 0, byteStream.Length);
        //    ms.Position = 0;

        //    Response.Buffer = true;
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=DatosCliente.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.End();
        //}
    }
}