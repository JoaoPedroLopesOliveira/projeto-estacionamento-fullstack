using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.Application.DTOs
{
    public class AdministradorCreateDTO
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nivel { get; set; }
    }
}