using A4S.CaseItau.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace A4S.CaseItau.Domain
{
    public class PostagensUsuarios
    {
        public List<Postagem> Postagens { get; private set; } = new List<Postagem>();
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();

        public PostagensUsuarios() { }
        public PostagensUsuarios(List<Postagem> postagens, List<Usuario> usuarios)
        {
            Postagens.AddRange(postagens);
            Usuarios.AddRange(usuarios);
        }

        public static async Task<PostagensUsuarios> CreateAsync(List<Postagem> postagens, Func<string, Task<List<Usuario>>> func)
        {
            if(postagens.Count == 0) return new PostagensUsuarios();

            var usuarios = await func.Invoke(RetornarIds(postagens));

            return new PostagensUsuarios(postagens, usuarios);
        }

        public static string RetornarIds(List<Postagem> postagens)
        {
            var ids = "";

            for (int i = 0; i < postagens.Count; i++)
            {
                var id = postagens[i].IdAuthor;

                if (i == 0) ids += $"{id}";
                else ids += $",{id}";
            }

            return ids;
        }
    }
}
