using A4S.CaseItau.Domain.Entidades;
using A4S.CaseItau.Domain.Response;
using System.Collections.Generic;
using System.Linq;

namespace A4S.CaseItau.Application.Handlers.Postagens.Response
{
    public class ColetarDadosResponse
    {
        public List<UsuarioResponse> TopUsuarios
        {
            get
            {
                return TopUsuariosRetorno();
            }
        }

        public int PostagensColetadas { get; private set; }

        private List<Usuario> _topUsuarios = new List<Usuario>();
        private int _quantidadeTopUsuariosColetados;

        public ColetarDadosResponse(int qtd) => this._quantidadeTopUsuariosColetados = qtd;

        public void AdicionarUsuarios(List<Usuario> usuarios)
        {
            if (usuarios != null)
            {
                HashSet<Usuario> hashSet = new HashSet<Usuario>(usuarios);

                _topUsuarios.AddRange(usuarios.GroupBy(u => u.Nome).Select(u => u.First()));
            }
        }
        public void AdicionarPostagens(List<Postagem> postagens) => PostagensColetadas += postagens.Count;
        private List<UsuarioResponse> TopUsuariosRetorno()
        {
            List<UsuarioResponse> top = new List<UsuarioResponse>();
            
            _topUsuarios.OrderByDescending(p => p.Seguidores)
                .Take(_quantidadeTopUsuariosColetados)
                .ToList().ForEach(u =>
                {
                    if (!top.Exists(ur => ur.Nome == u.Nome)) top.Add(new UsuarioResponse(u.Seguidores, u.Nome, u.UserName));
                });

            return top;
        }

        public static ColetarDadosResponse Create(int qtd) => new ColetarDadosResponse(qtd);
    }
}
