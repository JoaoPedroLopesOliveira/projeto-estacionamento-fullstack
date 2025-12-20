using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Entities;
using ApiEstacionamento.Infrastructure.Persistence.Entitites;

namespace ApiEstacionamento.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        Task<Veiculo?> GetByIdAsync(int id);
        Task<List<Veiculo>> GetAllAsync();
        Task<Veiculo> CreateAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo Veiculo);
        Task DeleteAsync(int id);
    }
}