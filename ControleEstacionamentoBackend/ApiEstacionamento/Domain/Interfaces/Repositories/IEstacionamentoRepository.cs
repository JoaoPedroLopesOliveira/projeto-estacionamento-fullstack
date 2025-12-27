using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Domain.Entities;

namespace ApiEstacionamento.Domain.Interfaces.Repositories
{
    public interface IEstacionamentoRepository 
    {
        Task<EstacionamentoConfig?> GetByIdAsync(int id);
        Task<List<EstacionamentoConfig>> GetAllAsync();
        
        Task<EstacionamentoConfig> CreateAsync(EstacionamentoConfig estacionamento);
        Task UpdateAsync(EstacionamentoConfig estacionamento);
        Task DeleteAsync(int id);
    }
}