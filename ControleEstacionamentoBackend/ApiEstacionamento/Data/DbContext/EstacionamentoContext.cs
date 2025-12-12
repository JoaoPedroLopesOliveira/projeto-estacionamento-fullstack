using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DbContext
{
    public class EstacionamentoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EstacionamentoContext (Microsoft.EntityFrameworkCore.DbContextOptions<EstacionamentoContext> options)
            : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<ApiEstacionamento.Models.Cliente> Clientes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ApiEstacionamento.Models.Veiculo> Veiculos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ApiEstacionamento.Models.Administrador> Administradores { get; set; }
    }
}