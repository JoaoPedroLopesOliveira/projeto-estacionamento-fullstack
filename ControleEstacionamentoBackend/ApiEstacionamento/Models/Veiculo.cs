using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstacionamento.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string Modelo { get; set; }
    
        [Required]
        public string Cor { get; set; }

        
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        
        public List<Ticket> Tickets { get; set; }
    }
}
