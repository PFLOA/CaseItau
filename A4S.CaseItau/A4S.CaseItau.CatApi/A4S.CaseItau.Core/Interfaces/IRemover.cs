using System.Threading.Tasks;

namespace A4S.CaseItau.Core.Interfaces
{
    public interface IRemover<TEntidade>
    {
        Task<bool> Remover(TEntidade entidade);
    }
}
