using A4S.CaseItau.Core.Interfaces;
using A4S.CaseItau.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace A4S.CaseItau.Domain.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<List<Usuario>> BuscarTopUsuariosSeguidores(int qtdUsuariosPesquisa);
    }
}
