using Microsoft.Extensions.Configuration;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Domain.Interface;
using System.Collections.Generic;
using A4S.CaseItau.Core.HTTP;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;

namespace A4S.CaseItau.HTTP
{
    public class CatApi : HttpBase, ICatApi
    {
        public CatApi(IConfiguration configuration) : base(configuration, "CatApi") { }

        public async Task<List<Raca>> ColetarGatosApi()
        {
            var retorno = await _url.AppendPathSegment("images")
                                .AppendPathSegment("search")
                                .SetQueryParams(new
                                {
                                    limit = "100",
                                    api_key = _key
                                }).GetJsonListAsync();

            return await RetornoGatos(retorno);
        }

        public async Task<List<Imagem>> ColetarImagensGatos(string idRaca)
        {
            var retorno = await _url.AppendPathSegment("images")
                                .AppendPathSegment("search")
                                .SetQueryParams(new
                                {
                                    breeds_ids = $"{idRaca}",
                                    limit = "100",
                                    api_key = _key
                                }).GetJsonListAsync();

            return await RetornoImagensGatos(retorno, idRaca);
        }

        private async Task<List<Imagem>> RetornoImagensGatos(dynamic data, string idRaca)
        {
            List<Imagem> imagens = new List<Imagem>();

            foreach (var item in data)
            {
                if (item is IDictionary<string, object> dict)
                {
                    if (dict.ContainsKey("categories"))
                        imagens.Add(new Imagem(item.id, idRaca, item.height.ToString(), item.width.ToString(), item.url, item.categories[0].name));
                    else
                        imagens.Add(new Imagem(item.id, idRaca, item.height.ToString(), item.width.ToString(), item.url));
                }
            }

            return await Task.FromResult(imagens);
        }
        private async Task<List<Raca>> RetornoGatos(dynamic data)
        {
            List<Raca> postagens = new List<Raca>();

            foreach (var item in data)
            {
                var breed = item.breeds;

                if (breed.Count > 0) postagens.Add(new Raca(breed[0].name, breed[0].temperament, breed[0].origin, breed[0].description, breed[0].id));
            }

            return await Task.FromResult(postagens);
        }
    }
}
