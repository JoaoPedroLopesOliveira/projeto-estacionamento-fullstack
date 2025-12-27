using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Domain.Entities;

namespace ApiEstacionamento.Domain.Interfaces.Repositories
{
    public interface IAdministradorRepository
    {
        public Task<Administrador?> GetByIdAsync(int id);
        public Task<List<Administrador>> GetAllAsync();
        public Task<Administrador> CreateAsync(Administrador administrador);

        public Task UpdateAsync(Administrador administrador);

        public Task DeleteAsync(int id);

        public Task<Administrador?> GetByLoginAsync(string login);
        
    }
}