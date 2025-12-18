using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DbContext;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using ApiEstacionamento.Models;
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

        public async Task<ClienteResponseDTO> CreateClienteAsync(ClienteCreateDTO clienteCreateDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreateDTO);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteResponseDTO>(cliente);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente == null)
            {
                return false;
            }
            _context.Clientes.Remove(cliente);
            return true;
        }

        public async Task<List<ClienteResponseDTO>> GetAllAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<List<ClienteResponseDTO>>(clientes);
        }

        public async Task<ClienteResponseDTO> GetClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente == null)
            {
                return null;
            }
            return _mapper.Map<ClienteResponseDTO>(cliente);
        }
        public async Task<ClienteResponseDTO> UpdateClienteAsync(int id, ClienteUpdateDTO clienteUpdateDTO)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(clienteUpdateDTO.Nome))
            {
                cliente.Nome = clienteUpdateDTO.Nome;
            }
            if (!string.IsNullOrEmpty(clienteUpdateDTO.Cpf))
            {
                cliente.Cpf = clienteUpdateDTO.Cpf;
            }
            if (!string.IsNullOrEmpty(clienteUpdateDTO.Telefone))
            {
                cliente.Telefone = clienteUpdateDTO.Telefone;
            }
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
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