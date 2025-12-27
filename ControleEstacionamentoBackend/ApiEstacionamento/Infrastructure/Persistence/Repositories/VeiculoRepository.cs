using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Infrastructure.Persistence.DbContext;
using ApiEstacionamento.Domain.Interfaces.Repositories;
using ApiEstacionamento.Domain.Entities;
using ApiEstacionamento.Infrastructure.Persistence.Entitites;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Infrastructure.Persistence.Repositories
{
        public class VeiculoRepository : IVeiculoRepository
    {
        private readonly EstacionamentoContext _context;
        private readonly IMapper _mapper;

        public VeiculoRepository(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Veiculo> CreateAsync(Veiculo veiculo)
        {
            var entity = _mapper.Map<VeiculoEntity>(veiculo);

            _context.Veiculos.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Veiculo>(entity);
        }

        public async Task<List<Veiculo>> GetAllAsync()
        {
            var entities = await _context.Veiculos.ToListAsync();
            return _mapper.Map<List<Veiculo>>(entities);
        }

        public async Task<Veiculo?> GetByIdAsync(int id)
        {
            var entity = await _context.Veiculos.FindAsync(id);
            if (entity == null) return null;
            return _mapper.Map<Veiculo>(entity);
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            var entity = await _context.Veiculos.FindAsync(veiculo.Id);
            if (entity == null) return;

            entity.Placa = veiculo.Placa;
            entity.Modelo = veiculo.Modelo;
            entity.Cor = veiculo.Cor;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Veiculos.FindAsync(id);
            if (entity == null) return;

            _context.Veiculos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}