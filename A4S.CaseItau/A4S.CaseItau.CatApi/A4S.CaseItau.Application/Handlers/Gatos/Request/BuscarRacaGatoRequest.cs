using A4S.CaseItau.Application.Handlers.Gatos.Response;
using System.ComponentModel.DataAnnotations;
using A4S.CaseItau.Core.Interfaces.Results;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Gatos.Request
{
    public class BuscarRacaGatoRequest : IRequest<IOperationResult<BuscarRacaGatoResponse>>
    {
        [Required]
        public string Id { get; set; }
    }
}
