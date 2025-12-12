using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstacionamento.Models
{
    public class Plano
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Tipo { get; set; } 

        [Required]
        public decimal Preco { get; set; }

        public int VeiculosPermitidos { get; set; }

        
        // Relacionamentos
        // Nullable para permitir planos globais
        public int? EstacionamentoConfigId { get; set; }
        public EstacionamentoConfig EstacionamentoConfig { get; set; }

        public List<ClientePlano> ClientesComEstePlano { get; set; }
    }
}
