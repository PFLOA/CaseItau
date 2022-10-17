using System.Threading.Tasks;

namespace A4S.CaseItau.Domain.Interface
{
    public interface ITwitterApi
    {
        Task<PostagensUsuarios> PostagensUsuariosRetorno(string hashtag);
    }
}
