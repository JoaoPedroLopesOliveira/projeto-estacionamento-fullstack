using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Entities
{
    public class EstacionamentoConfig
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Localizacao { get; set; }

        [Required]
        public int CapacidadeMaxima { get; set; }

        [Required]
        public decimal PrecoPorHora { get; set; }

        [Required]
        public TimeSpan HorarioAbertura { get; set; }

        [Required]
        public TimeSpan HorarioFechamento { get; set; }

        // RELACIONAMENTOS
        public List<Plano> Planos { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
