using Challenge_Backend_Financas.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Backend_Financas.Configuracoes
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
