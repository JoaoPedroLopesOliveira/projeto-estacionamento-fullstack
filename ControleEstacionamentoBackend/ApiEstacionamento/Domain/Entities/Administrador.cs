using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Domain.Entities
{
    public class Administrador
    {
        public int Id {get; set; }
        public string Login {get; set; } = null!;
        public string SenhaHash {get; set; } = null!;

        public Enuns.NivelAdministrador Nivel {get; set; }

        public DateTime DataCriacao {get; set; } = DateTime.UtcNow;
    }
}