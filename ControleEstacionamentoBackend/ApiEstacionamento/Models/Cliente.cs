using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstacionamento.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set; }
        [Required]
        public string Nome {get; set; }
        [Required]
        public string Cpf {get; set; }
        
        [Required]
        public string Telefone {get; set; }
        
        public List<Veiculo> Veiculos {get; set; }
    }
}