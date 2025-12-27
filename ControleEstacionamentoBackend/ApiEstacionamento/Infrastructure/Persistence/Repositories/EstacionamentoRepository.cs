using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Infrastructure.Persistence.DbContext;
using ApiEstacionamento.Domain.Entities;
using ApiEstacionamento.Domain.Interfaces.Repositories;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Infrastructure.Persistence.Entitites;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Infrastructure.Persistence.Repositories
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {

        private readonly EstacionamentoContext _context;
        private readonly IMapper _mapper;

        public EstacionamentoRepository(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<EstacionamentoConfig> CreateAsync(EstacionamentoConfig estacionamento)
        {
            var entity = _mapper.Map<EstacionamentoEntity>(estacionamento);
            _context.Estacionamentos.Add(entity);
            _context.SaveChanges();
            return Task.FromResult(_mapper.Map<EstacionamentoConfig>(entity));
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Estacionamentos.FindAsync(id);
            if (entity == null) return;
            _context.Estacionamentos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EstacionamentoConfig>> GetAllAsync()
        {
            var entities = await _context.Estacionamentos.ToListAsync();
            return _mapper.Map<List<EstacionamentoConfig>>(entities);
        }

        public async Task<EstacionamentoConfig?> GetByIdAsync(int id)
        {
            var entity = await _context.Estacionamentos.FindAsync(id);
            if(entity == null) return null;
            return _mapper.Map<EstacionamentoConfig>(entity);
        }

        public async Task UpdateAsync(EstacionamentoConfig estacionamento)
        {
            var entity = await _context.Estacionamentos.FindAsync(estacionamento.Id);
            if (entity == null) return;

            entity.Localizacao = estacionamento.Localizacao;
            entity.HorarioAbertura = estacionamento.HorarioAbertura;
            entity.HorarioFechamento = estacionamento.HorarioFechamento;
            entity.CapacidadeMaxima = estacionamento.CapacidadeMaxima;
            entity.PrecoHora = estacionamento.PrecoPorHora;

            await _context.SaveChangesAsync();
        }

    }
}