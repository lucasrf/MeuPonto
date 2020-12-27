using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MeuPonto;

namespace Blazor_PDF.PDF
{
    public class EspelhoPonto
    {
        public static void GeneratePage(Document pdf, PdfWriter writer, Funcionario funcionario, Periodo periodo)
        {
            // TABLES
            var title = new Paragraph("Mês referência: " + periodo.GetDescricao(), new Font(Font.HELVETICA, 20, Font.BOLD));
            pdf.Add(title);
            var funcNome = new Paragraph("Funcionário: " + funcionario.Codigo + " - " + funcionario.Nome, new Font(Font.HELVETICA, 12));
            pdf.Add(funcNome);


            List<Ponto> pontos = funcionario.GetMarcacoesByPeriodo(periodo);

            Table datatable = new Table(3);
            datatable.Padding = 0;
            datatable.Spacing = 2;
            

            float[] headerwidths = { 20, 30, 20 };

            datatable.Widths = headerwidths;
            datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;

            int m = 0;
            Font fontCells = FontFactory.GetFont("Arial", 10, BaseColor.Black);
            for (int i = 0; i < pontos.Count; i++)
            {
                m += i;
                datatable.AddCell(new Phrase(pontos[i].Date.ToShortDateString(),fontCells));
                datatable.AddCell(new Phrase(pontos[i].GetMarcacoes(), fontCells));
                datatable.AddCell(new Phrase(pontos[i].GetJornada().ToString(), fontCells));
            }

            TimeSpan jornadaTotal = TimeSpan.Zero;
            foreach (var ponto in pontos)
            {
                jornadaTotal += ponto.GetJornada();
            }

            datatable.AddCell(new Phrase("TOTAL", fontCells));
            datatable.AddCell("");
            datatable.AddCell(new Phrase(jornadaTotal.ToString(),fontCells));

            pdf.Add(datatable);
            
        }
    }
}
