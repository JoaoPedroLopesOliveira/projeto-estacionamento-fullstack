using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ApiEstacionamento.Infrastructure.Persistence.Entitites
{
    [Table("veiculos")]
    public class VeiculoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}

        [Required]
        public string Placa {get;set;}= null!;
        [Required]
        public string Modelo {get;set;}= null!;
        [Required]
        public string Cor {get;set;}= null!;
        public int? ClienteId {get; set;}
    }
}