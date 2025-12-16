using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class ClienteCreateDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        [Required]
        public string Telefone { get; set; }

    }
}