using Challenge_Backend_Financas.Entities;
using Challenge_Backend_Financas.Entities.Categorias;
using Challenge_Backend_Financas.Models;

namespace Challenge_Backend_Financas.Repositories.Interfaces
{
    public interface ICategoriasRepository
    {
        public CategoriasResponse GetById(int id);
        public List<Categoria> List();
        public Response Add(CategoriasRequest request);
        public Response Update(int id, CategoriasRequest request);
        public Response Delete(int id);
    }
}
