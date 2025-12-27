using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Domain.Entities;

namespace ApiEstacionamento.Domain.Interfaces.Repositories
{
    public interface IClienteRepositorie
    {
        Task<Cliente?> GetByIdAsync(int id);
        Task<List<Cliente>> GetAllAsync();
        Task CreateClienteAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int idCliente);
        
        Task<List<Veiculo>> GetVeiculosDoClienteAsync(int clienteId);

        Task<Plano> VinculaNovoPlanoAoCliente(int idCliente, Plano plano);

        Task<bool> RemoverPlanoDoCliente(int idCliente);
        Task<List<Veiculo>> VinculaNovoVeiculoAoCliente(int idCliente, Veiculo veiculo);
        Task<List<Veiculo>> RemoverVeiculoDoCliente(int idCliente, Veiculo veiculo);
    }
}