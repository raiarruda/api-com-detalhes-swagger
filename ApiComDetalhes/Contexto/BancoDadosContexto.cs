using ApiComDetalhes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComDetalhes.Contexto
{
    public class BancoDadosContexto : DbContext
    {
        public BancoDadosContexto(DbContextOptions<BancoDadosContexto> options) : base(options)
        {
        }

        protected BancoDadosContexto()
        {
        }

        public DbSet<Models.Task> Tarefas { get; set; } = default!;
        public DbSet<Category> Categorias { get; set; } = default!;
    }
}