using Challenge_Backend_Financas.Entities.Categorias;
using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Repositories.Interfaces
{
    public interface ICategoriasRepository
    {
        public CategoriasResponse GetById(int id);
        public List<Categoria> List();
        public bool Add(CategoriasRequest request);
        public bool Update(int id, CategoriasRequest request);
        public bool Delete(int id);
    }
}
