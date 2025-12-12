using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace ApiEstacionamento.Models
{
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set; }
        [Required]
        public string Placa {get; set; }
        [Required]
        public string Modelo {get; set; }
        [Required]
        public string Cor {get; set; }

        [ForeignKey("Cliente")]
        public int? ClienteId {get; set; }
        
        public Cliente Cliente {get; set; }
    }
}