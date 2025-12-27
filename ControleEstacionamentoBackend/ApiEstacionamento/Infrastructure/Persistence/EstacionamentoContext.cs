using Microsoft.EntityFrameworkCore;
using ApiEstacionamento.Infrastructure.Persistence.Entitites;

namespace ApiEstacionamento.Infrastructure.Persistence.DbContext
{
    public class EstacionamentoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EstacionamentoContext(DbContextOptions<EstacionamentoContext> options)
            : base(options)
        {
        }

        public DbSet<ClienteEntity> Clientes => Set<ClienteEntity>();
        public DbSet<VeiculoEntity> Veiculos => Set<VeiculoEntity>();
        public DbSet<PlanoEntity> Planos => Set<PlanoEntity>();
        public DbSet<ClientePlanoEntity> ClientesPlanos => Set<ClientePlanoEntity>();
        public DbSet<TicketEntity> Tickets => Set<TicketEntity>();
        public DbSet<EstacionamentoEntity> Estacionamentos => Set<EstacionamentoEntity>();
        public DbSet<AdministradorEntity> Administradores => Set<AdministradorEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* ================================
               CLIENTE 1:N VEÍCULOS
               ================================ */
            modelBuilder.Entity<VeiculoEntity>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Veiculos)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            /* ================================
               CLIENTE ↔ PLANO (N:N)
               ================================ */
            modelBuilder.Entity<ClientePlanoEntity>()
                .HasKey(cp => new { cp.ClienteId, cp.PlanoId });

            modelBuilder.Entity<ClientePlanoEntity>()
                .HasOne(cp => cp.Cliente)
                .WithMany(c => c.HistoricoDePlanos)
                .HasForeignKey(cp => cp.ClienteId);

            modelBuilder.Entity<ClientePlanoEntity>()
                .HasOne(cp => cp.Plano)
                .WithMany(p => p.ClientesComEstePlano)
                .HasForeignKey(cp => cp.PlanoId);

            /* ================================
               ESTACIONAMENTO 1:N PLANOS
               ================================ */
            modelBuilder.Entity<PlanoEntity>()
                .HasOne(p => p.Estacionamento)
                .WithMany(e => e.Planos)
                .HasForeignKey(p => p.EstacionamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            /* ================================
               TICKET → VEÍCULO
               ================================ */
            modelBuilder.Entity<TicketEntity>()
                .HasOne(t => t.Veiculo)
                .WithMany(v => v.Tickets)
                .HasForeignKey(t => t.VeiculoId);

            /* ================================
               CONFIGURAÇÃO DE DECIMAIS
               ================================ */
            modelBuilder.Entity<PlanoEntity>()
                .Property(p => p.Preco)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EstacionamentoEntity>()
                .Property(e => e.PrecoHora)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TicketEntity>()
                .Property(t => t.ValorFinal)
                .HasPrecision(10, 2);
        }
    }
}
