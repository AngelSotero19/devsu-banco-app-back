using banco_api.Application.UseCases.Reports.Dtos;
using banco_api.Application.UseCases.Reports.Queries.GetStatementReport;
using banco_api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace banco_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStatementPdfGenerator _pdfGenerator;

        public ReportController(IMediator mediator, IStatementPdfGenerator pdfGenerator)
        {
            _mediator = mediator;
            _pdfGenerator = pdfGenerator;
        }

        /// <summary>
        /// Obtiene el estado de cuenta en JSON.
        /// </summary>
        [HttpGet("statement/json")]
        public async Task<ActionResult<IEnumerable<StatementMovementDto>>> GetStatementJson(
            [FromQuery] string clientId,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var query = new GetStatementReportQuery(clientId, startDate, endDate);
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("No se encontraron movimientos para ese rango de fechas.");

            return Ok(result);
        }

        /// <summary>
        /// Obtiene el estado de cuenta en base64.
        /// </summary>
        [HttpGet("statement/pdf-file")]
        public async Task<IActionResult> GetStatementPdfFile([FromQuery] string clientId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var query = new GetStatementReportQuery(clientId, startDate, endDate);
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("No se encontraron movimientos para ese rango de fechas.");
            var clientInfo = result.First();
            var report = new StatementReportResult
            {
                ClientName = clientInfo.ClientName,
                AccountNumber = clientInfo.AccountNumber,
                ClientId = clientId,
                StartDate = startDate,
                EndDate = endDate,
                Movements = result.ToList()
            };

            var pdfBase64 = _pdfGenerator.GeneratePdf(report);
            var fileBytes = Convert.FromBase64String(pdfBase64);

            return File(fileBytes, "application/pdf", $"EstadoCuenta_{clientId}_{DateTime.Now:yyyyMMddHHmmss}.pdf");
        }

    }
}
