using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Application.Interfaces.Services;
using ApiEstacionamento.Domain.Interfaces.Repositories;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Infrastructure.Security;
using ApiEstacionamento.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ApiEstacionamento.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAdministradorRepository _administradorRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(IAdministradorRepository administradorRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _administradorRepository = administradorRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<LoginResponseDTO> GetAdministradorByLoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var admin = await _administradorRepository.GetByLoginAsync(loginRequestDTO.Login);

            if(admin == null || !_passwordHasher.Verify(loginRequestDTO.Senha, admin.SenhaHash))
            {
                throw new UnauthorizedAccessException("Login ou senha invalidos.");
            }

            return new LoginResponseDTO
            {
                Token = _tokenService.GenerateToken(admin),
                Expiration = DateTime.UtcNow.AddHours(2)
            };

        }
    }
}