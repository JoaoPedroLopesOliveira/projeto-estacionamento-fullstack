using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;

namespace ApiEstacionamento.Interfaces
{
    public interface IEstacionamentoService
    {
        public Task<EstacionamentoConfigResponseDTO> CreateEStacionamentoAsync(EstacionamentoConfigCreateDTO estacionamentoCreateDTO);
        public Task<EstacionamentoConfigResponseDTO> GetEstacionamentoByIdAsync(int id);
        public Task<List<EstacionamentoConfigResponseDTO>> GetEstacionamentoAsync();

        public Task<bool> DeleteEstacionamento(int id);
        public Task<EstacionamentoConfigResponseDTO> UpdateEstacionamentoAsync(int id, EstacionamentoConfigUpdateDTO estacionamentoUpdateDTO);
    }
}