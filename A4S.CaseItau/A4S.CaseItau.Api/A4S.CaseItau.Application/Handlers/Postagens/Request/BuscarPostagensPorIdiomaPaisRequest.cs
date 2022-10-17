using A4S.CaseItau.Application.Handlers.Postagens.Response;
using A4S.CaseItau.Core.Interfaces.Results;
using System.Collections.Generic;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Postagens.Request
{
    public class BuscarPostagensPorIdiomaPaisRequest : IRequest<IOperationResult<List<BuscarPostagensPorIdiomaPaisResponse>>> { }
}
