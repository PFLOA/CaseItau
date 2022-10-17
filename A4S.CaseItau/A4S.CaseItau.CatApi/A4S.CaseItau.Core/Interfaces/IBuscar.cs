using System.Threading.Tasks;
using System;

namespace A4S.CaseItau.Core.Interfaces
{
    public interface IBuscar<TEntidade>
    {
        Task<TEntidade> BuscarPorGuid(Guid guid);
        Task<TEntidade> BuscarPorId<T>(T id);
    }
}
