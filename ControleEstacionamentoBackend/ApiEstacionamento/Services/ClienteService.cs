using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DbContext;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Services
{
    public class ClienteService : IClienteService
    {
        readonly EstacionamentoContext _context;
        readonly Mapper _mapper;

        public ClienteService(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = (Mapper)mapper;
        }

        public async Task<List<VeiculoResponseDTO>> GetVeiculosDoClienteAsync(int ClienteId)
        {
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == ClienteId);
            if (!clienteExiste)
            {
                throw new Exception("Cliente não encontrado");
            }
            var veiculos = await _context.Veiculos
                .Where(v => v.ClienteId == ClienteId)
                .ToListAsync();

            return _mapper.Map<List<VeiculoResponseDTO>>(veiculos);
        }
    }
}