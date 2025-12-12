using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class EstacionamentoConfigResponseDTO
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public int CapacidadeTotal { get; set; }
        public decimal PrecoHora { get; set; }
        public TimeSpan HorarioAbertura { get; set; }
        public TimeSpan HorarioFechamento { get; set; }
       
    }
}