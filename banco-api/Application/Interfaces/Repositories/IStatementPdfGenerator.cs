using banco_api.Application.UseCases.Reports.Dtos;

namespace banco_api.Application.Interfaces.Repositories
{
    public interface IStatementPdfGenerator
    {
        string GeneratePdf(StatementReportResult report);
    }
}