using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class EstacionamentoConfigCreateDTO
    {
        public string Localizacao { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal PrecoHora { get; set; }
        public TimeSpan HorarioAbertura { get; set; }
        public TimeSpan HorarioFechamento { get; set; }
    }
}