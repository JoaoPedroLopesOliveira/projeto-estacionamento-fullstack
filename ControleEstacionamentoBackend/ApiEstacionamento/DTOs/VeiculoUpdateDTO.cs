using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class VeiculoUpdateDTO
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
    }
}