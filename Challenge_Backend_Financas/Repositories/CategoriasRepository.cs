using Challenge_Backend_Financas.Configuracoes;
using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Entities.Categorias;
using Challenge_Backend_Financas.Models;
using Challenge_Backend_Financas.Repositories.Interfaces;

namespace Challenge_Backend_Financas.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly Contexto dbContext;

        public CategoriasRepository(Contexto dbContext)
        {
            this.dbContext = dbContext;
        }

        public Response Add(CategoriasRequest request)
        {
            try
            {
                var categoriaQuery = dbContext.Categorias.Where(c => c.NomeCategoria == request.Nome);
                if (categoriaQuery != null)
                {
                    return new Response() { Mensagem = "Essa categoria já está cadastrada" };
                }

                var categoriaDb = new Categoria()
                {
                    Id = request.Id,
                    NomeCategoria = request.Nome
                };
                dbContext.Categorias.Add(categoriaDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Categoria adicionada com sucesso" };
            }
            catch
            {
                return new Response() { Mensagem = "Ocorreu um erro ao adicionar a categoria" };
            }
        }

        public Response Delete(int id)
        {
            try
            {
                var categoriaDb = dbContext.Categorias.Find(id);
                dbContext.Categorias.Remove(categoriaDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Categoria removida com sucesso" };
            }
            catch
            {
                return new Response() { Mensagem = "Erro ao remover categoria" };
            }
        }

        public CategoriasResponse GetById(int id)
        {
            var categoriaDb = dbContext.Categorias.Find(id);
            var categoriaResponse = new CategoriasResponse()
            {
                Id = categoriaDb.Id,
                CategoriaNome = categoriaDb.NomeCategoria
            };
            return categoriaResponse;
        }

        public List<Categoria> List()
        {
            return dbContext.Categorias.ToList();
        }

        public Response Update(int id, CategoriasRequest request)
        {
            try
            {
                var categoriaQuery = dbContext.Categorias.Where(c => c.NomeCategoria.Equals(request.Nome)).FirstOrDefault();
                if (categoriaQuery != null)
                {
                    return new Response() { Mensagem = "Erro, categoria já existente" };
                }
                var categoriaDb = dbContext.Categorias.Find(id);
                categoriaDb.NomeCategoria = request.Nome;
                dbContext.Update(categoriaDb);
                dbContext.SaveChanges();
                return new Response() { Mensagem = "Categoria atualizada com sucesso" };
            }
            catch
            {
                return new Response() { Mensagem = "Ocorreu um erro ao atualizar categoria" };
            }
        }
    }
}
