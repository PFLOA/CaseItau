using System.Threading.Tasks;
using System;

namespace A4S.CaseItau.Core.Interfaces
{
    public interface IAtualizar<TEntidade>
    {
        Task<Guid> Alterar(TEntidade entidade);
    }
}
