using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstacionamento.Entities
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

        public int QuantidadeVeiculosPermitidos { get; set; }
        
        [Required]
        public string Description {get; set;}
        
        // Relacionamentos
        // Nullable para permitir planos globais
        // Estacionamentos permitidos por ID
        public int? EstacionamentoConfigId { get; set; }

        // Estacionamento permitidos por localização
        public List<string> localizacoesPermitidas {get; set;}
        public EstacionamentoConfig EstacionamentoConfig { get; set; }

        public List<ClientePlano> ClientesComEstePlano { get; set; }
    }
}
