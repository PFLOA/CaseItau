using A4S.CaseItau.Application.Handlers.Gatos.Response;
using A4S.CaseItau.Core.Interfaces.Results;
using System.Collections.Generic;
using A4S.CaseItau.Domain.Filter;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Gatos.Request
{
    public class BuscarRacasGatosRequest : BuscarRacasGatosRequestFilter, IRequest<IOperationResult<List<BuscarRacasGatosResponse>>> { }
}
