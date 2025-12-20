using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Entities;

namespace ApiEstacionamento.Interfaces
{
    public interface IPlanoService
    {
        public Task<PlanoResponseDTO> CreatePlanoAsync(PlanoCreateDTO planoCreateDTO);
        public Task<PlanoResponseDTO> GetPlanoByIdAsync(int idPlano);
        public Task<List<PlanoResponseDTO>> GetAllPlanosAsync();
        public Task<bool> DeletePlanoAsync(int id);
        public Task<PlanoResponseDTO> UpdatePlanoAsync(int id,PlanoUpdateDTO planoUpdateDTO);
    }
}