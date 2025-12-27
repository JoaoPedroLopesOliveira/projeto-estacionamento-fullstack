using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Enuns;

namespace ApiEstacionamento.Infrastructure.Persistence.Entitites
{
    [Table("Tickets")]
    public class TicketEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VeiculoId { get; set; }
        [Required]
        public VeiculoEntity Veiculo { get; set; } = null!;

        public TicketStatus TicketStatus { get; set; } = TicketStatus.ABERTO;
        [Required]
        public int EstacionamentoConfigId { get; set; }
        [Required]
        public EstacionamentoEntity EstacionamentoConfig { get; set; } = null!;

        [Required]
        public DateTime Entrada { get; set; } = DateTime.UtcNow;
        public DateTime? Saida { get; set; }

        
        public decimal? ValorFinal { get; set; }
        [Required]
        public bool CobradoPorPlano { get; set; } = false;
    }
}