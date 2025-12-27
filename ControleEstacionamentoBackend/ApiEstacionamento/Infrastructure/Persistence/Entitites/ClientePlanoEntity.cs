using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Infrastructure.Persistence.Entitites
{
    public class ClientePlanoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public int ClienteId { get; set; }
        public ClienteEntity Cliente { get; set; } = null!;

        
        public int PlanoId { get; set; }
        public PlanoEntity Plano { get; set; } = null!;
        
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }

        public bool Ativo { get; set; }
    }
}