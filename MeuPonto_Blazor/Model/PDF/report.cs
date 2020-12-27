using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MeuPonto;
using Microsoft.JSInterop;

namespace Blazor_PDF.PDF
{
    public class Report
    {
        public void Generate(IJSRuntime js, string filename, Funcionario funcionario, Periodo periodo)
        {
            js.InvokeVoidAsync( "jsSaveAsFile",
                                filename,
                                Convert.ToBase64String(ReportPDF(funcionario, periodo))
                                );
        }

        private byte[] ReportPDF(Funcionario funcionario, Periodo periodo)
        {
            var memoryStream = new MemoryStream();

            // Marge in centimeter, then I convert with .ToDpi()
            float margeLeft = 1.5f;
            float margeRight= 1.5f;
            float margeTop = 1.0f;
            float margeBottom = 1.0f;

            Document pdf = new Document(
                                    PageSize.A4,
                                    margeLeft.ToDpi(),
                                    margeRight.ToDpi(),
                                    margeTop.ToDpi(),
                                    margeBottom.ToDpi()
                                   );

            pdf.AddTitle("Relatório");
            pdf.AddAuthor( "MeuPonto");
            pdf.AddCreationDate();
            pdf.AddKeywords("meuponto");
            pdf.AddSubject("Relatório MeuPonto");

            PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);

            //HEADER and FOOTER
            var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);
            var labelHeader = new Chunk("Relatório de Espelho de Ponto", fontStyle);
            HeaderFooter header = new HeaderFooter(new Phrase(labelHeader), false)
            {
                BackgroundColor = new BaseColor(0,0,0),
                Alignment = Element.ALIGN_CENTER,
                Border = Rectangle.NO_BORDER
            };
            //header.Border = Rectangle.NO_BORDER;
            pdf.Header = header;


            var labelFooter = new Chunk("Page", fontStyle);
            HeaderFooter footer = new HeaderFooter(new Phrase(labelFooter), true)
            {
                Border = Rectangle.NO_BORDER,
                Alignment = Element.ALIGN_RIGHT
            };
            pdf.Footer = footer;

            pdf.Open();

           EspelhoPonto.GeneratePage(pdf, writer, funcionario, periodo);

            pdf.Close();

            return memoryStream.ToArray();
        }
    }
}
