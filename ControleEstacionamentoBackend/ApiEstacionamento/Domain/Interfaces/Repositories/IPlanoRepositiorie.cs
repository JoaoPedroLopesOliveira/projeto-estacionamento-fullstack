using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Domain.Entities;

namespace ApiEstacionamento.Domain.Interfaces.Repositories
{
    public interface IPlanoRepositiorie
    {
        Task<Plano?> GetByIdAsync(int id);
        Task<List<Plano>> GetAllAsync();
        Task<Plano> CreateAsync(Plano plano);
        Task UpdateAsync(Plano plano);
        Task DeleteAsync(int id);
    }
}