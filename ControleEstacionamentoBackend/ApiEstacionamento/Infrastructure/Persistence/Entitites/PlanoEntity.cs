using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ApiEstacionamento.Infrastructure.Persistence.Entitites
{
    [Table("Planos")]
    public class PlanoEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string Tipo { get; set; } =null!;

        [Required]
        public decimal Preco { get; set; }

        public int QuantidadeVeiculosPermitidos { get; set; }
        
        [Required]
        public string Description {get; set;} = null!;

        // Relacionamentos
        // Nullable para permitir planos globais
        // Estacionamentos permitidos por ID
        public int? EstacionamentoId { get; set; }

        // Estacionamento permitidos por localização
        public List<string> LocalizacoesPermitidas {get; set;} = new();
        public EstacionamentoEntity Estacionamento { get; set; } = null!;

        public List<ClientePlanoEntity> ClientesComEstePlano { get; set; } = new();
    }
}
