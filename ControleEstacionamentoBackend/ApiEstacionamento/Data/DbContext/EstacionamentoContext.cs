using Microsoft.EntityFrameworkCore;
using ApiEstacionamento.Models;

namespace ApiEstacionamento.DbContext
{
    public class EstacionamentoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EstacionamentoContext(DbContextOptions<EstacionamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<ClientePlano> ClientesPlanos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<EstacionamentoConfig> Estacionamentos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cliente 1:N Veículos
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Veiculos)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.ClienteId);

            // Cliente 1:N Planos
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.HistoricoDePlanos)
                .WithOne(cp => cp.Cliente)
                .HasForeignKey(cp => cp.ClienteId);

            // Plano 1:N ClientePlano
            modelBuilder.Entity<Plano>()
                .HasMany(p => p.ClientesComEstePlano)
                .WithOne(cp => cp.Plano)
                .HasForeignKey(cp => cp.PlanoId);

            // EstacionamentoConfig 1:N Planos
            modelBuilder.Entity<EstacionamentoConfig>()
                .HasMany(e => e.Planos)
                .WithOne(p => p.EstacionamentoConfig)
                .HasForeignKey(p => p.EstacionamentoConfigId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔥 CONFIGURAÇÃO DE DECIMAIS (ESSENCIAL)
            modelBuilder.Entity<Plano>()
                .Property(p => p.Preco)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EstacionamentoConfig>()
                .Property(e => e.PrecoPorHora)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.ValorFinal)
                .HasPrecision(10, 2);
        }

    }
}
