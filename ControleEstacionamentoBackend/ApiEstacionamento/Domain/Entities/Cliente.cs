using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public List<Veiculo> Veiculos { get; set; } = new();

        public List<ClientePlano> HistoricoDePlanos { get; set; } = new();
    }
}
