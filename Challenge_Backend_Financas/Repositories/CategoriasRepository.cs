using Challenge_Backend_Financas.Configuracoes;
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

        public bool Add(CategoriasRequest request)
        {
            try
            {
                var categoriaDb = new Categoria()
                {
                    Id = request.Id,
                    NomeCategoria = request.Nome
                };
                dbContext.Categorias.Add(categoriaDb);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var categoriaDb = dbContext.Categorias.Find(id);
                dbContext.Categorias.Remove(categoriaDb);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
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

        public bool Update(int id, CategoriasRequest request)
        {
            try
            {
                var categoriaDb = dbContext.Categorias.Find(id);
                categoriaDb.NomeCategoria = request.Nome;
                dbContext.Update(categoriaDb);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
