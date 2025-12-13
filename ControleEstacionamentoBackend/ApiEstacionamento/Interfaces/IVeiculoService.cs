using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Models;

namespace ApiEstacionamento.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoResponseDTO> CreateVeiculoAsync(VeiculoCreateDTO veiculoCreateDTO);
        Task<VeiculoResponseDTO> GetVeiculoByIdAsync(int id);
        Task<bool> DeleteVeiculoByIdAsync(int id);
        Task<List<VeiculoResponseDTO>> GetAllVeiculosAsync();
        Task<VeiculoResponseDTO>UpdateVeiculoAsync(int id, VeiculoUpdateDTO veiculoUpdateDTO);
    }
}