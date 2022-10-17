namespace A4S.CaseItau.Core.Interfaces
{
    public interface IRepository<TEntidade> : IAdicionar<TEntidade>, IRemover<TEntidade>, IBuscar<TEntidade>, IAtualizar<TEntidade>
    {
    }
}
