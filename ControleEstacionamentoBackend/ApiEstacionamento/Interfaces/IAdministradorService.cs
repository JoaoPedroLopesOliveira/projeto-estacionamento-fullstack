using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Enuns;
using ApiEstacionamento.Models;

namespace ApiEstacionamento.Interfaces
{
    public interface IAdministradorService
    {
        public Task<AdministradorResponseDTO> GetAdministradorByIdAsync(int id);
        public Task<List<AdministradorResponseDTO>> GetAllAdministradoresAsync();
        public Task<AdministradorResponseDTO> CreateAdministradorAsync(AdministradorCreateDTO administradorCreateDTO);
        public Task<AdministradorResponseDTO> UpdateAdministradorAsync(int id, AdministradorUpdateDTO administradorUpdateDTO);

        public Task<bool> DeleteAdministradorByIdAsync(int id);

    }
}