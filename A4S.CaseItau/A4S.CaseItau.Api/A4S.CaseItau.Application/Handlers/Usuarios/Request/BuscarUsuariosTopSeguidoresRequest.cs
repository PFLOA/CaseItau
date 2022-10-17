using A4S.CaseItau.Application.Handlers.Usuarios.Response;
using System.ComponentModel.DataAnnotations;
using A4S.CaseItau.Core.Interfaces.Results;
using System.Collections.Generic;
using System.ComponentModel;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Usuarios.Request
{
    public class BuscarUsuariosTopSeguidoresRequest : IRequest<IOperationResult<List<BuscarUsuariosTopSeguidoresResponse>>>
    {
        [Required]
        [Description("Quantidade de usuários a serem retornados pela consulta.")]
        public int QtdUsuariosRetorno { get; set; }
    }
}
