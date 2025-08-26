using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Reports.Dtos;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace banco_api.Infrastructure.Repositories
{
    public class StatementPdfGenerator : IStatementPdfGenerator
    {
        public string GeneratePdf(StatementReportResult report)
        {
            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    // =======================
                    // Encabezado
                    // =======================
                    page.Header().Text($"Estado de Cuenta - {report.ClientName}")
                        .SemiBold().FontSize(18).FontColor(Colors.Blue.Medium);

                    // =======================
                    // Cuerpo
                    // =======================
                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        col.Item().Text($"Número de cuenta: {report.AccountNumber}")
                            .FontSize(12).FontColor(Colors.Grey.Darken2);

                        col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                        col.Item().Table(table =>
                        {
                            // Definición de columnas
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(2);
                                c.RelativeColumn(2);
                                c.RelativeColumn(2);
                                c.RelativeColumn(2);
                            });

                            // Encabezado de tabla
                            table.Header(h =>
                            {
                                h.Cell().Element(HeaderCellStyle).Text("Fecha");
                                h.Cell().Element(HeaderCellStyle).Text("Tipo");
                                h.Cell().Element(HeaderCellStyle).Text("Valor");
                                h.Cell().Element(HeaderCellStyle).Text("Saldo");
                            });

                            // Filas dinámicas con los movimientos
                            foreach (var item in report.Movements)
                            {
                                table.Cell().Element(CellStyle)
                                    .Text(item.Date.HasValue ? item.Date.Value.ToString("dd/MM/yyyy HH:mm") : "");

                                table.Cell().Element(CellStyle)
                                    .Text(item.MovementType ?? "");

                                table.Cell().Element(CellStyle)
                                    .Text(item.Value.HasValue ? item.Value.Value.ToString("C2") : "0,00");

                                table.Cell().Element(CellStyle)
                                    .Text(item.Balance.HasValue ? item.Balance.Value.ToString("C2") : "0,00");
                            }
                        });
                    });

                    // =======================
                    // Pie de página
                    // =======================
                    page.Footer().AlignRight().Text(t =>
                    {
                        t.Span("Generado el ").FontSize(10).FontColor(Colors.Grey.Darken1);
                        t.Span(DateTime.Now.ToString("dd/MM/yyyy HH:mm")).FontSize(10).Bold();
                    });
                });
            });

            using var ms = new MemoryStream();
            doc.GeneratePdf(ms);
            return Convert.ToBase64String(ms.ToArray());
        }

        private static IContainer HeaderCellStyle(IContainer c) =>
            c.PaddingVertical(5).Background(Colors.Grey.Lighten3)
             .BorderBottom(1).BorderColor(Colors.Black);

        private static IContainer CellStyle(IContainer c) =>
            c.PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
    }
}
