using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Domain.Entities
{
    public class EstacionamentoConfig
    {
        public int Id { get; set; } 
  
        public string Localizacao { get; set; } = null!;

        public int CapacidadeMaxima { get; set; } = 0;

        public decimal PrecoPorHora { get; set; } = 0;

        public TimeSpan HorarioAbertura { get; set; } = TimeSpan.Zero;

        public TimeSpan HorarioFechamento { get; set; } = TimeSpan.Zero;

        public List<Plano> Planos { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
