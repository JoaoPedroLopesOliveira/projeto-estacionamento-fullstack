using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class AdministradorResponseDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nivel { get; set; }
    }
}