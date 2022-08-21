using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;

namespace Challenge_Backend_Financas.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly Contexto dbContext;

        public UsuariosRepository(Contexto dbContext)
        {
            this.dbContext = dbContext;
        }

        public Response Add(UsuarioRequest request)
        {
            try
            {
                if(VerificaEmailCadastrado(request) != null)
                {
                    return new Response() { Mensagem = "Esse email já está cadastrado" };
                }

                var usuarioDb = new Usuario()
                {
                    Email = request.Email,
                    Senha = request.Senha
                };
                dbContext.Usuarios.Add(usuarioDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Usuário cadastrado com sucesso" };

            }
            catch
            {
                return new Response() { Mensagem = "Ocorreu um erro ao cadastrar usuario" };
            }
        }

        public bool ExisteUsuario(UsuarioRequest request)
        {
            var user = dbContext.Usuarios
                .Where(u => u.Email == request.Email)
                .Where(u => u.Senha == request.Senha)
                .FirstOrDefault();
            return user != null;
        }

        public Usuario VerificaEmailCadastrado(UsuarioRequest request)
        {
            return dbContext.Usuarios.Where(u => u.Email == request.Email).FirstOrDefault();
        }
    }
}
