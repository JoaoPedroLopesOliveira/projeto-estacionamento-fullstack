using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class EstacionamentoService : IEstacionamentoService
    {

        private readonly EstacionamentoContext _contexto;
        private readonly Mapper _mapper;

        public EstacionamentoService(EstacionamentoContext context, IMapper mapper)
        {
            _contexto = context;
            _mapper = (Mapper)mapper;
        }

        public async Task<EstacionamentoConfigResponseDTO> CreateEStacionamentoAsync(EstacionamentoConfigCreateDTO estacionamentoCreateDTO)
        {
            var estacionamento =  _mapper.Map<EstacionamentoConfig>(estacionamentoCreateDTO);
            _contexto.Estacionamentos.Add(estacionamento);
            await _contexto.SaveChangesAsync();
            return _mapper.Map<EstacionamentoConfigResponseDTO>(estacionamento);
        }

        public async Task<bool> DeleteEstacionamento(int id)
        {
            var estacionamento = await _contexto.Estacionamentos.FindAsync(id);
            if(estacionamento == null)
            {
                return false;
            }
            _contexto.Estacionamentos.Remove(estacionamento);
            await _contexto.SaveChangesAsync();
            return true;

        }

        public async Task<List<EstacionamentoConfigResponseDTO>> GetEstacionamentoAsync()
        {
            var estacionamentos = await _contexto.Estacionamentos.ToListAsync();
            return _mapper.Map<List<EstacionamentoConfigResponseDTO>>(estacionamentos);
        }

        public async Task<EstacionamentoConfigResponseDTO> GetEstacionamentoByIdAsync(int id)
        {
            var estacionamento = await _contexto.Estacionamentos.FindAsync(id);
            if(estacionamento == null)
            {
                return null;
            }
            return _mapper.Map<EstacionamentoConfigResponseDTO>(estacionamento);
        }

        public async Task<EstacionamentoConfigResponseDTO> UpdateEstacionamento(int id, EstacionamentoConfigUpdateDTO estacionamentoUpdateDTO)
        {
            var estacionamento = await _contexto.Estacionamentos.FindAsync(id);
            if(estacionamento == null)
            {
                return null;
            }
            if(estacionamentoUpdateDTO.CapacidadeMaxima != 0)
            {
                estacionamento.CapacidadeMaxima = estacionamentoUpdateDTO.CapacidadeMaxima;
            }
            if(estacionamentoUpdateDTO.HorarioAbertura != TimeSpan.Zero)
            {
                estacionamento.HorarioAbertura = estacionamentoUpdateDTO.HorarioAbertura;
            }
            if(estacionamentoUpdateDTO.HorarioFechamento != TimeSpan.Zero)
            {
                estacionamento.HorarioFechamento = estacionamentoUpdateDTO.HorarioFechamento;
            }
            if(estacionamentoUpdateDTO.PrecoHora > 0)
            {
                estacionamento.PrecoPorHora = estacionamentoUpdateDTO.PrecoHora;
            }
            await _contexto.SaveChangesAsync();
            return _mapper.Map<EstacionamentoConfigResponseDTO>(estacionamento);
        }
    }
}