using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstacionamento.Domain.Entities
{
    public class ClientePlano
    {
        public int Id { get; set; }

        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        
        public int PlanoId { get; set; }
        public Plano Plano { get; set; }
        
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }

        public bool Ativo { get; set; }
    }
}
