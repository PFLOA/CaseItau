using A4S.CaseItau.Domain.Entidades;

namespace A4S.CaseItau.Application.Handlers.Usuarios.Response
{
    public class BuscarUsuariosTopSeguidoresResponse
    {
        public int Seguidores { get; set; }
        public int Seguindo { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public BuscarUsuariosTopSeguidoresResponse() { }

        public BuscarUsuariosTopSeguidoresResponse(Usuario usuario)
        {
            Seguidores = usuario.Seguidores;
            Seguindo = usuario.Seguindo;
            Nome = usuario.Nome;
            UserName = usuario.UserName;
        }

        public static implicit operator BuscarUsuariosTopSeguidoresResponse(Usuario usuario)
        {
            return new BuscarUsuariosTopSeguidoresResponse(usuario);
        }
    }
}
