using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DbContext;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Enuns;
using ApiEstacionamento.Interfaces;
using ApiEstacionamento.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Services
{
    public class AdministradorService : IAdministradorService
    {

        private readonly EstacionamentoContext _context;
        private readonly Mapper _mapper;
        public AdministradorService(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = (Mapper)mapper;
        }
        
        public async Task<AdministradorResponseDTO> CreateAdministradorAsync(AdministradorCreateDTO administradorCreateDTO)
        {
            var adm = new Administrador
            {
                Login = administradorCreateDTO.Login,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(administradorCreateDTO.Senha),
                Nivel = Enum.Parse<Enuns.NivelAdministrador>(administradorCreateDTO.Nivel)
            };
            _context.Administradores.Add(adm);
            await _context.SaveChangesAsync();
            return _mapper.Map<AdministradorResponseDTO>(adm);
        }

        public Task<bool> DeleteAdministradorByIdAsync(int id)
        {
            var administrador = _context.Administradores.FirstOrDefault(a => a.Id == id);
            if (administrador == null)
            {
                throw new Exception("Administrador não encontrado.");
            }
            _context.Administradores.Remove(administrador);
            return _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public async Task<AdministradorResponseDTO> GetAdministradorByIdAsync(int id)
        {
            var administrador = await _context.Administradores.FirstOrDefaultAsync(a => a.Id == id);
            if (administrador == null)
            {
                throw new Exception("Administrador não encontrado.");
            }
            return _mapper.Map<AdministradorResponseDTO>(administrador);
        }

        public async Task<List<AdministradorResponseDTO>> GetAllAdministradoresAsync()
        {
            var administradores = await _context.Administradores.ToListAsync();
            return _mapper.Map<List<AdministradorResponseDTO>>(administradores);
        }

        public Task<AdministradorResponseDTO> UpdateAdministradorAsync(int id, AdministradorUpdateDTO administradorUpdateDTO)
        {
            var administrador = _context.Administradores.FirstOrDefault(a => a.Id == id);
            if (administrador == null)
            {
                throw new Exception("Administrador não encontrado.");
            }
            if (!string.IsNullOrEmpty(administradorUpdateDTO.Login))
            {
                administrador.Login = administradorUpdateDTO.Login;
            }
            if (!string.IsNullOrEmpty(administradorUpdateDTO.Senha))
            {
                administrador.SenhaHash = BCrypt.Net.BCrypt.HashPassword(administradorUpdateDTO.Senha);
            }
            administrador.Nivel = Enum.Parse<Enuns.NivelAdministrador>(administradorUpdateDTO.Nivel);
            _context.Administradores.Update(administrador);
            return _context.SaveChangesAsync().ContinueWith(t =>
            {
                if (t.Result > 0)
                {
                    return _mapper.Map<AdministradorResponseDTO>(administrador);
                }
                throw new Exception("Erro ao atualizar o administrador.");
            });
        }
    }
}