
using ApiEstacionamento.Application.DTOs;
using ApiEstacionamento.Domain.Entities;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Enuns;
using ApiEstacionamento.Interfaces;
using AutoMapper;
using ApiEstacionamento.Domain.Interfaces.Repositories;
using ApiEstacionamento.Infrastructure.Security;

namespace ApiEstacionamento.Services
{
    public class AdministradorService : IAdministradorService
    {


        private readonly IAdministradorRepository _adminRepository;        
        private readonly IMapper _mapper;

        private readonly IPasswordHasher _passwordHasher = new BCryptPasswordHasher();
        public AdministradorService(IAdministradorRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<AdministradorResponseDTO> CreateAdministradorAsync(AdministradorCreateDTO administradorCreateDTO)
        {
            var administrador = new Administrador
            {
                Login = administradorCreateDTO.Login,
                SenhaHash = _passwordHasher.Hash(administradorCreateDTO.Senha),
                Nivel = Enum.Parse<NivelAdministrador>(administradorCreateDTO.Nivel)
            };
            await _adminRepository.CreateAsync(administrador);
            return _mapper.Map<AdministradorResponseDTO>(administrador);
        }

        public async Task<bool> DeleteAdministradorByIdAsync(int id)
        {
            var administrador = await _adminRepository.GetByIdAsync(id);
            if (administrador == null)
            {
                return false;
            }
            await _adminRepository.DeleteAsync(id);
            return true;
        }

        public async Task<AdministradorResponseDTO> GetAdministradorByIdAsync(int id)
        {
            var administrador = await _adminRepository.GetByIdAsync(id);
            return _mapper.Map<AdministradorResponseDTO>(administrador);
        }

        public async Task<Administrador?> GetAdministradorByLoginAsync(string login)
        {
            return await _adminRepository.GetByLoginAsync(login);
        }

        public async Task<List<AdministradorResponseDTO>> GetAllAdministradoresAsync()
        {
            var administradores = await _adminRepository.GetAllAsync();
            return _mapper.Map<List<AdministradorResponseDTO>>(administradores);
        }

        public async Task<AdministradorResponseDTO> UpdateAdministradorAsync(int id, AdministradorUpdateDTO administradorUpdateDTO)
        {
            var administrador = await _adminRepository.GetByIdAsync(id);
            if (administrador == null){
                return null;
            }
            if (!string.IsNullOrEmpty(administradorUpdateDTO.Senha))
            {
                administrador.SenhaHash = BCrypt.Net.BCrypt.HashPassword(administradorUpdateDTO.Senha);
            }
            if (!string.IsNullOrEmpty(administradorUpdateDTO.Login))
            {
                administrador.Login = administradorUpdateDTO.Login;
            }
            if (!string.IsNullOrEmpty(administradorUpdateDTO.Nivel)){
                administrador.Nivel = Enum.Parse<NivelAdministrador>(administradorUpdateDTO.Nivel);
            }
            await _adminRepository.UpdateAsync(administrador);
            return _mapper.Map<AdministradorResponseDTO>(administrador);
        }
    }
}