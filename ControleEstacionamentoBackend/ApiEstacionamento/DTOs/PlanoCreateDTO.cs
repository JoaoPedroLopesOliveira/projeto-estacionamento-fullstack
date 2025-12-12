using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class PlanoCreateDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public decimal Preco { get; set; }

        public int VeiculosPermitidos { get; set; }

        public int? EstacionamentoConfigId { get; set; }
    }
}