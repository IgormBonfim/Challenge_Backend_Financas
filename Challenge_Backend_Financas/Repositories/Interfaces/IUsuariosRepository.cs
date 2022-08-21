using Challenge_Backend_Financas.Entities;

namespace Challenge_Backend_Financas.Repositories.Interfaces
{
    public interface IUsuariosRepository
    {
        public Response Add(UsuarioRequest request);
        public bool ExisteUsuario(UsuarioRequest request);
    }
}
