using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEstacionamento.Domain.Entities
{
    public class Veiculo
    {
        public int Id{get;set;}
        public string Placa{get;set;} = null!;
        public string Modelo{get;set;} = null!;
        public string Cor{get;set;} = null!;
        public int? ClienteId {get;set;}

        public Cliente? Cliente{get;set;}

        public List<Ticket> tickets {get;set;} = new(); 
    }
}
