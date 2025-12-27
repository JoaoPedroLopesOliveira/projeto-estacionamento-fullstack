using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class TicketCreateDTO
    {
        [Required]
        public int VeiculoId { get; set; }

        [Required]
        public int EstacionamentoConfigId { get; set; }
        
    }
}