using Microsoft.Extensions.Configuration;
using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Domain.Interface;
using System.Collections.Generic;
using A4S.CaseItau.Core.HTTP;
using System.Threading.Tasks;
using A4S.CaseItau.Domain;
using Flurl.Http;
using System;
using Flurl;

namespace A4S.CaseItau.HTTP
{
    public class TwitterApi : HttpBase, ITwitterApi
    {
        public TwitterApi(IConfiguration configuration) : base(configuration, "Twitter") { }

        public async Task<PostagensUsuarios> PostagensUsuariosRetorno(string hashtag)
        {
            PostagensUsuarios postagensUsuarios = await PostagensUsuarios.CreateAsync(await Postagens(hashtag), Usuarios);

            return postagensUsuarios;
        }
        private async Task<List<Postagem>> Postagens(string hashtag)
        {
            var retorno = await _url.WithOAuthBearerToken(_bearer)
                                .AppendPathSegment("tweets")
                                .AppendPathSegment("search")
                                .AppendPathSegment("recent")
                                .SetQueryParams(new
                                {
                                    query = $"#{hashtag}",
                                    max_results = "100"
                                })
                                .SetQueryParam("expansions", "author_id")
                                .SetQueryParam("user.fields", "created_at")
                                .SetQueryParam("tweet.fields", "geo,created_at,lang")
                                .GetJsonAsync();

            if (retorno is IDictionary<string, object> dict)
            {
                if (dict.ContainsKey("data")) return await RetornoPostagens(retorno.data);
            }

            return await Task.FromResult(new List<Postagem>());
        }

        private async Task<List<Usuario>> Usuarios(string ids)
        {
            try
            {
                var retorno = await _url.WithOAuthBearerToken(_bearer)
                                        .AppendPathSegment($"users")
                                        .SetQueryParam("ids", ids)
                                        .SetQueryParam("user.fields", "public_metrics")
                                        .GetJsonAsync();

                if (retorno is IDictionary<string, object> dict)
                {
                    if (dict.ContainsKey("data")) return await RetornoUsuarios(retorno.data);
                }

                return await Task.FromResult(new List<Usuario>());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<Postagem>> RetornoPostagens(dynamic data)
        {
            List<Postagem> postagens = new List<Postagem>();

            foreach (var item in data)
            {
                postagens.Add(new Postagem(Convert.ToInt64(item.id), Convert.ToInt64(item.author_id), item.text, item.created_at, item.lang));
            }

            return await Task.FromResult(postagens);
        }

        private async Task<List<Usuario>> RetornoUsuarios(dynamic data)
        {
            List<Usuario> usuarios = new List<Usuario>();

            foreach (var item in data)
            {
                usuarios.Add(new Usuario(Convert.ToInt32(item.public_metrics.followers_count), Convert.ToInt32(item.public_metrics.following_count), Convert.ToInt64(item.id), item.name, item.username));
            }

            return await Task.FromResult(usuarios);
        }
    }
}
