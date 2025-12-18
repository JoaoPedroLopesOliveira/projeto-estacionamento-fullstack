using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Models;

namespace ApiEstacionamento.Interfaces
{
    public interface IClienteService
    {
        public Task <ClienteResponseDTO> CreateClienteAsync(ClienteCreateDTO clienteCreateDTO);
        public Task<List<VeiculoResponseDTO>> GetVeiculosDoClienteAsync(int clienteId);
        public Task<ClienteResponseDTO> UpdateClienteAsync(int id, ClienteUpdateDTO clienteUpdateDTO);

        public Task<bool> DeleteCliente(int id);

        public Task<List<ClienteResponseDTO>> GetAllAsync();

        public Task<ClienteResponseDTO> GetClienteAsync(int id);

        public Task<List<VeiculoResponseDTO>> VinculaNovoVeiculoAoCliente(int idCliente, int Idveiculo);
        public Task<PlanoResponseDTO> VinculaNovoPlanoAoCliente(int idCliente, int IdPlano);

        public Task<bool> RemoverPlanoDoCliente(int idCliente);
        public Task<List<VeiculoResponseDTO>> RemoverVeiculoDoCliente(int idCliente, int Idveiculo);

    }
}