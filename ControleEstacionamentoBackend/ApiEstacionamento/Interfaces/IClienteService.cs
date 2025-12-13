using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;

namespace ApiEstacionamento.Interfaces
{
    public interface IClienteService
    {
        Task<List<VeiculoResponseDTO>> GetVeiculosDoClienteAsync(int clienteId);
    }
}