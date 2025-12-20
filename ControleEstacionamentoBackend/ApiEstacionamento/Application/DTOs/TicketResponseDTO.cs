using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class TicketResponseDTO
    {
        public int Id { get; set; }
        public string PlacaVeiculo { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSaida { get; set; }

        public decimal? ValorFinal { get; set; }

        public bool CobradoPorPlano { get; set; }

        public EstacionamentoConfigResponseDTO EstacionamentoConfig { get; set; }

    }
}