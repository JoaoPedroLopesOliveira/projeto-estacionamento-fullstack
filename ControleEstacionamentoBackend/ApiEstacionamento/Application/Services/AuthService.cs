using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DbContext;
using ApiEstacionamento.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ApiEstacionamento.Enuns;
using ApiEstacionamento.Entities;

namespace ApiEstacionamento.Services
{
    public class AuthService
    {
        private readonly EstacionamentoContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(EstacionamentoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequest)
        {
            var administrador = await _context.Administradores
                .FirstOrDefaultAsync(a => a.Login == loginRequest.Login);

            if (administrador == null)
                throw new Exception("Administrador não encontrado.");

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Senha, administrador.SenhaHash))
                throw new Exception("Senha incorreta.");

            var token = GerarToken(administrador);

            return new LoginResponseDTO
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(2)
            };
        }

        private string GerarToken(Administrador administrador)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, administrador.Id.ToString()),
            new Claim(ClaimTypes.Name, administrador.Login),
            new Claim(ClaimTypes.Role, Enum.GetName(typeof(NivelAdministrador), administrador.Nivel)!)
        };

            var jwtKey = _configuration["Jwt:Key"]
                ?? throw new Exception("JWT Key não configurada");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}