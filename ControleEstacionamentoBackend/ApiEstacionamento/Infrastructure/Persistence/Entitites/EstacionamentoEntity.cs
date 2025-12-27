using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Infrastructure.Persistence.Entitites
{
    [Table("Estacionamentos")]
    public class EstacionamentoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Required]
        public string Localizacao {get;set;} = null!;  
        [Required]
        public int CapacidadeMaxima{get;set;}

        [Required]
        public decimal PrecoHora {get;set;}
        [Required]
        public TimeSpan HorarioAbertura {get; set;}
        [Required]
        public TimeSpan HorarioFechamento {get; set;}

        public List<PlanoEntity> Planos { get; set; } = new();
        public List<TicketEntity> Tickets { get; set; } = new();
        
    }
}