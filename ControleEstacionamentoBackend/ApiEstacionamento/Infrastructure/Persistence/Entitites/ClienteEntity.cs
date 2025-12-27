using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Infrastructure.Persistence.Entitites
{
    [Table("Clientes")]
    public class ClienteEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; } = null!;

        [Required]
        public string Telefone { get; set; } = null!;

        public List<VeiculoEntity> Veiculos { get; set; } = new();

        public List<ClientePlanoEntity> HistoricoDePlanos { get; set; } = new();
    }
}