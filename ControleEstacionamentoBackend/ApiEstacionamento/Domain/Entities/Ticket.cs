using System;
using System.ComponentModel.DataAnnotations;
using ApiEstacionamento.Enuns;

namespace ApiEstacionamento.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public TicketStatus ticketStatus;
        public int EstacionamentoConfigId { get; set; }
        public EstacionamentoConfig EstacionamentoConfig { get; set; }

        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }

        
        public decimal? ValorFinal { get; set; }
        public bool CobradoPorPlano { get; set; }
    }
}
