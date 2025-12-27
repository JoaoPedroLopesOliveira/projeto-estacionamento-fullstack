using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Infrastructure.Persistence.DbContext;
using ApiEstacionamento.Domain.Entities;
using ApiEstacionamento.Domain.Interfaces.Repositories;
using ApiEstacionamento.Infrastructure.Persistence.Entitites;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Infrastructure.Persistence.Repositories
{
    public class PlanoRepository : IPlanoRepositiorie
    {
        private readonly EstacionamentoContext _context;
        private readonly IMapper _mapper;
        public PlanoRepository(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Plano> CreateAsync(Plano plano)
        {
            var entity = _mapper.Map<PlanoEntity>(plano);
            _context.Planos.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Plano>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Planos.FindAsync(id);
            if (entity == null) return;
            _context.Planos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Plano>> GetAllAsync()
        {
            var entities = await _context.Planos.ToListAsync();
            return _mapper.Map<List<Plano>>(entities);
        }

        public async Task<Plano?> GetByIdAsync(int id)
        {
         var entity = await _context.Planos.FindAsync(id);
         if (entity == null)
            {
                return null;
            }
            return _mapper.Map<Plano>(entity);   
        }

        public async Task UpdateAsync(Plano plano)
        {
            var entity = _context.Planos.Find(plano.Id);
            if(entity == null) return;

            entity.Nome = plano.Nome;
            entity.Tipo = plano.Tipo;
            entity.Preco = plano.Preco;
            entity.QuantidadeVeiculosPermitidos = plano.QuantidadeVeiculosPermitidos;
            entity.Description = plano.Description;
            await _context.SaveChangesAsync();
        }
    }
}