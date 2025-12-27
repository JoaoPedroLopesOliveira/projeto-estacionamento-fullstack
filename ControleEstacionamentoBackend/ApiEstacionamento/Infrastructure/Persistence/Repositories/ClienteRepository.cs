using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Domain.Entities;
using ApiEstacionamento.Domain.Interfaces.Repositories;
using ApiEstacionamento.Infrastructure.Persistence.DbContext;
using ApiEstacionamento.Infrastructure.Persistence.Entitites;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepositorie
    {
        private readonly EstacionamentoContext _context;
        private readonly IMapper _mapper;
        public ClienteRepository(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateClienteAsync(Cliente cliente)
        {
            var entity = _mapper.Map<ClienteEntity>(cliente);
            await _context.Clientes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            if (entity == null) return;
            _context.Clientes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            var entities = await _context.Clientes.ToListAsync();
            return _mapper.Map<List<Cliente>>(entities);
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            return _mapper.Map<Cliente?>(entity);
        }
        public async Task UpdateAsync(Cliente cliente)
        {
            var entity = await _context.Clientes.FindAsync(cliente.Id);
            if (entity == null) return;
            entity.Nome = cliente.Nome;
            entity.Cpf = cliente.Cpf;
            entity.Telefone = cliente.Telefone;
            await _context.SaveChangesAsync();
        }

        public Task<List<Veiculo>> GetVeiculosDoClienteAsync(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverPlanoDoCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<Veiculo>> RemoverVeiculoDoCliente(int idCliente, Veiculo veiculo)
        {
            throw new NotImplementedException();
        }


        public Task<Plano> VinculaNovoPlanoAoCliente(int idCliente, Plano plano)
        {
            throw new NotImplementedException();
        }

        public Task<List<Veiculo>> VinculaNovoVeiculoAoCliente(int idCliente, Veiculo veiculo)
        {
            throw new NotImplementedException();
        }
    }
}