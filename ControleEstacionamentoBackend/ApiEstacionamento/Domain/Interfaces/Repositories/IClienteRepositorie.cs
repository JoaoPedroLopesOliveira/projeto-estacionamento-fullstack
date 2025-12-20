using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Entities;

namespace ApiEstacionamento.Domain.Interfaces.Repositories
{
    public interface IClienteRepositorie
    {
        Task<Cliente?> GetByIdAsync(int id);
        Task<List<Cliente>> GetAllAsync();
        Task CreateClienteAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }
}