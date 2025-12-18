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
        //tipo: mensal/semanal
        public string Tipo { get; set; }
        [Required]
        public decimal Preco { get; set; }

        //quantidade
        public int VeiculosPermitidos { get; set; }

        public string Description {get;set;}

        //null para ser valido em todos os estacionamentos
        public int? EstacionamentoConfigId { get; set; }

        //localizações que o plano é valido 
        public List<string> localizacoes {get;set;}
    }
}