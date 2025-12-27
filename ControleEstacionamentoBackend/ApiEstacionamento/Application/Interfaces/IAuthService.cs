using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;

namespace ApiEstacionamento.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> GetAdministradorByLoginAsync(LoginRequestDTO requestDTO);
    }
}