using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstacionamento.DTOs
{
    public class LoginRequestDTO
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}