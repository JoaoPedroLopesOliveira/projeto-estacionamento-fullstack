using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DbContext;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Services
{
    public class ClienteService : IClienteService
    {
        readonly EstacionamentoContext _context;
        readonly Mapper _mapper;

        public ClienteService(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = (Mapper)mapper;
        }

        public Task<ClienteResponseDTO> CreateClienteAsync(ClienteCreateDTO clienteCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteResponseDTO> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClienteResponseDTO> GetClienteAsync()
        {
            throw new NotImplementedException();
        }


        public Task<bool> RemoverPlanoDoCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<VeiculoResponseDTO>> RemoverVeiculoDoCliente(int idCliente, int Idveiculo)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteResponseDTO> UpdateClienteAsync(int id, ClienteUpdateDTO clienteUpdateDTO)
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
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == ClienteId);
            if (!clienteExiste)
            {
                throw new Exception("Cliente não encontrado");
            }
            var veiculos = await _context.Veiculos
                .Where(v => v.ClienteId == ClienteId)
                .ToListAsync();

            return _mapper.Map<List<VeiculoResponseDTO>>(veiculos);
        }
    }
}