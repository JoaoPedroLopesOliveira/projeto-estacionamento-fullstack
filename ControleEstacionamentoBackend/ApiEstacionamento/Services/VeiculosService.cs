using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DbContext;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using ApiEstacionamento.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiEstacionamento.Services
{
    public class VeiculosService : IVeiculoService
    {
        private readonly EstacionamentoContext _context;
        private readonly IMapper _mapper;
        public VeiculosService(EstacionamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VeiculoResponseDTO> CreateVeiculoAsync(VeiculoCreateDTO veiculoCreateDTO)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoCreateDTO);
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return _mapper.Map<VeiculoResponseDTO>(veiculo);
        }

        public async Task<bool> DeleteVeiculoByIdAsync(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return false;
            }
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<VeiculoResponseDTO> GetVeiculoByIdAsync(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return null;  
            }
            return _mapper.Map<VeiculoResponseDTO>(veiculo);
        }

        public async Task<List<VeiculoResponseDTO>> GetAllVeiculosAsync()
        {
            var veiculos = await _context.Veiculos.ToListAsync();
            return _mapper.Map<List<VeiculoResponseDTO>>(veiculos);
        }

        public async Task<VeiculoResponseDTO> UpdateVeiculoAsync(int id, VeiculoUpdateDTO veiculoUpdateDTO)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return null; 
            }
            if (!string.IsNullOrEmpty(veiculoUpdateDTO.Placa))
            {
                veiculo.Placa = veiculoUpdateDTO.Placa;
            }
            if (!string.IsNullOrEmpty(veiculoUpdateDTO.Modelo))
            {
                veiculo.Modelo = veiculoUpdateDTO.Modelo;
            }
            if (!string.IsNullOrEmpty(veiculoUpdateDTO.Cor))
            {
                veiculo.Cor = veiculoUpdateDTO.Cor;
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<VeiculoResponseDTO>(veiculo);
        }
    }
}