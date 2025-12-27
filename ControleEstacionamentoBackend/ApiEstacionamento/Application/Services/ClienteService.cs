
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApiEstacionamento.Domain.Entities;
using ApiEstacionamento.Interfaces;
using ApiEstacionamento.Domain.Interfaces.Repositories;
using ApiEstacionamento.DTOs;

namespace ApiEstacionamento.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepositorie _clienteRepository;
        readonly Mapper _mapper;

        public ClienteService(IClienteRepositorie clienteRepository, IMapper mapper)
        {

            _mapper = (Mapper)mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteResponseDTO> CreateClienteAsync(ClienteCreateDTO clienteCreateDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreateDTO);
            await _clienteRepository.CreateClienteAsync(cliente);
            return _mapper.Map<ClienteResponseDTO>(cliente);
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var existente = await _clienteRepository.GetByIdAsync(id);
            if (existente == null)
                return false;

            await _clienteRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<ClienteResponseDTO>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return _mapper.Map<List<ClienteResponseDTO>>(clientes);
        }

        public async Task<ClienteResponseDTO> GetClienteAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return null;
            }
            return _mapper.Map<ClienteResponseDTO>(cliente);
        }
        public async Task<ClienteResponseDTO> UpdateClienteAsync(int id, ClienteUpdateDTO clienteUpdateDTO)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return null;

            if (!string.IsNullOrEmpty(clienteUpdateDTO.Nome))
                cliente.Nome = clienteUpdateDTO.Nome;

            if (!string.IsNullOrEmpty(clienteUpdateDTO.Cpf))
                cliente.Cpf = clienteUpdateDTO.Cpf;

            if (!string.IsNullOrEmpty(clienteUpdateDTO.Telefone))
                cliente.Telefone = clienteUpdateDTO.Telefone;

            await _clienteRepository.UpdateAsync(cliente);
            return _mapper.Map<ClienteResponseDTO>(cliente);
        }


        public Task<bool> RemoverPlanoDoCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<VeiculoResponseDTO>> RemoverVeiculoDoCliente(int idCliente, int Idveiculo)
        {
            throw new NotImplementedException();
        }


        public Task<PlanoResponseDTO> VinculaNovoPlanoAoCliente(int idCliente, int IdPlano)
        {
            throw new NotImplementedException();
        }

        public Task<List<VeiculoResponseDTO>> VinculaNovoVeiculoAoCliente(int idCliente, int Idveiculo)
        {
            throw new NotImplementedException();
        }
        public async Task<List<VeiculoResponseDTO>> GetVeiculosDoClienteAsync(int ClienteId)
        {
            throw new NotImplementedException();
        }
    }
}