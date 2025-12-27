using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Domain.Entities;

namespace ApiEstacionamento.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(Administrador administrador);
    }
}