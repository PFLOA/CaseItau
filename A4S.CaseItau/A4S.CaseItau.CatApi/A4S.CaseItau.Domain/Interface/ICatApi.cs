using A4S.CaseItau.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace A4S.CaseItau.Domain.Interface
{
    public interface ICatApi
    {
        Task<List<Raca>> ColetarGatosApi();
        Task<List<Imagem>> ColetarImagensGatos(string idRaca);
    }
}
