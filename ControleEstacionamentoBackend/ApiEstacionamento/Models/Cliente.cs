using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiEstacionamento.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        public string Telefone { get; set; }

        public List<Veiculo> Veiculos { get; set; }

        public List<ClientePlano> HistoricoDePlanos { get; set; }
    }
}
