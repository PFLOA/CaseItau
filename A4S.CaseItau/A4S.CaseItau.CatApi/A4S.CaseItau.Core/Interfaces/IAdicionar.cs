using System.Collections.Generic;
using System.Threading.Tasks;

namespace A4S.CaseItau.Core.Interfaces
{
    public interface IAdicionar<TEntidade>
    {
        Task<TEntidade> Criar(TEntidade entidade);
        Task Criar(List<TEntidade> entidade);
    }
}
