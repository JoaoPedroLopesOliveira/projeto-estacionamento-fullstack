using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiEstacionamento.Domain.Entities;

namespace ApiEstacionamento.Domain.Entities
{
    public class Plano
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;


        public string Tipo { get; set; } = null!;

        public decimal Preco { get; set; }

        public int QuantidadeVeiculosPermitidos { get; set; }
        
        public string Description {get; set;} = null!;
        
        // Relacionamentos
        // Nullable para permitir planos globais
        // Estacionamentos permitidos por ID
        public int? EstacionamentoConfigId { get; set; }

        // Estacionamento permitidos por localização
        public List<string> LocalizacoesPermitidas {get; set;} = new();
        public EstacionamentoConfig EstacionamentoConfig { get; set; } = null!;

        public List<ClientePlano> ClientesComEstePlano { get; set; } = new();
    }
}
