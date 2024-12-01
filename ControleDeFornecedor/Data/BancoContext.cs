using Microsoft.EntityFrameworkCore;
using ControleDeFornecedor.Models;

namespace ControleDeFornecedor.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<FornecedorModel> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FornecedorModel>()
                .ToTable("Fornecedores");  // Certifique-se de que o nome da tabela no banco seja 'Fornecedores'
        }
    }
}
