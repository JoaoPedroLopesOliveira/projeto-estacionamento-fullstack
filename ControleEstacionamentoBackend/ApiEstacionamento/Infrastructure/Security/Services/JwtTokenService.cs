using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiEstacionamento.Application.Interfaces.Services;
using ApiEstacionamento.Domain.Entities;
using ApiEstacionamento.Enuns;
using Microsoft.IdentityModel.Tokens;

namespace ApiEstacionamento.Infrastructure.Auth
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Administrador administrador)
        {
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
}