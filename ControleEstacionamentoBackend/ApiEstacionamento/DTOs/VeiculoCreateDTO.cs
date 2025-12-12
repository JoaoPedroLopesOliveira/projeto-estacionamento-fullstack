using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class VeiculoCreateDTO
    {
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Cor { get; set; }
    }
}