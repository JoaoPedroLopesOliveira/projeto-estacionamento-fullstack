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
    public class AdministradorRepository : IAdministradorRepository
    {

        private readonly EstacionamentoContext _context;
        private readonly IMapper _mapper;
        public AdministradorRepository(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Administrador> CreateAsync(Administrador administrador)
        {
            var entity = _mapper.Map<AdministradorEntity>(administrador);
            await _context.Administradores.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Administrador>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Administradores.FindAsync(id);
            if (entity == null)
            {
                return;
            }
            _context.Administradores.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Administrador>> GetAllAsync()
        {
            var entities = await _context.Administradores.ToListAsync();
            return _mapper.Map<List<Administrador>>(entities);
        }

        public async Task<Administrador?> GetByIdAsync(int id)
        {
            var entity = await _context.Administradores.FindAsync(id);
            return _mapper.Map<Administrador?>(entity);
        }

        public async Task<Administrador?> GetByLoginAsync(string login)
        {
            var entity = await _context.Administradores.AsNoTracking().FirstOrDefaultAsync(a => a.Login == login);
            return _mapper.Map<Administrador?>(entity);
        }

        public async Task UpdateAsync(Administrador administrador)
        {
            var entity = await _context.Administradores.FindAsync(administrador.Id);
            if (entity == null) return;
            entity.Login = administrador.Login;
            entity.SenhaHash = administrador.SenhaHash;
            entity.Nivel = administrador.Nivel;
            await _context.SaveChangesAsync();
        }
    }
}