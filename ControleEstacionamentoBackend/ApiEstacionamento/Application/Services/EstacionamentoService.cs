using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Infrastructure.Persistence.DbContext;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApiEstacionamento.Domain.Entities;
using ApiEstacionamento.Domain.Interfaces.Repositories;

namespace ApiEstacionamento.Services
{
    public class EstacionamentoService : IEstacionamentoService
    {

        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IMapper _mapper;

        public EstacionamentoService(IEstacionamentoRepository estacionamentoRepository, IMapper mapper)
        {
            _estacionamentoRepository = estacionamentoRepository;
            _mapper = mapper;
        }

        public async Task<EstacionamentoConfigResponseDTO> CreateEStacionamentoAsync(EstacionamentoConfigCreateDTO estacionamentoCreateDTO)
        {
            var estacionamento = _mapper.Map<EstacionamentoConfig>(estacionamentoCreateDTO);
            await _estacionamentoRepository.CreateAsync(estacionamento);
            return _mapper.Map<EstacionamentoConfigResponseDTO>(estacionamento);
        }

        public async Task<bool> DeleteEstacionamento(int id)
        {
            var estacionamento = _estacionamentoRepository.GetByIdAsync(id);
            if (estacionamento == null)
            {
                return false;
            }
            await _estacionamentoRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<EstacionamentoConfigResponseDTO>> GetEstacionamentoAsync()
        {
            var estacionamentos = await _estacionamentoRepository.GetAllAsync();
            return _mapper.Map<List<EstacionamentoConfigResponseDTO>>(estacionamentos);
        }

        public async Task<EstacionamentoConfigResponseDTO> GetEstacionamentoByIdAsync(int id)
        {
            var estacionamento = await _estacionamentoRepository.GetByIdAsync(id);
            if (estacionamento == null)
            {
                return null;
            }
            return _mapper.Map<EstacionamentoConfigResponseDTO>(estacionamento);
        }

        public async Task<EstacionamentoConfigResponseDTO?> UpdateEstacionamentoAsync(int id,EstacionamentoConfigUpdateDTO dto)
        {
            var estacionamento = await _estacionamentoRepository.GetByIdAsync(id);
            if (estacionamento == null){
                return null;
            }
            if (!string.IsNullOrEmpty(dto.Localizacao)){
                estacionamento.Localizacao = dto.Localizacao;
            }
            if(dto.CapacidadeMaxima > 0){
                estacionamento.CapacidadeMaxima = dto.CapacidadeMaxima;
            }
            if(dto.PrecoHora > 0){
                estacionamento.PrecoPorHora = dto.PrecoHora;
            }
            if(dto.HorarioAbertura != TimeSpan.Zero){
                estacionamento.HorarioAbertura = dto.HorarioAbertura;
            }
            await _estacionamentoRepository.UpdateAsync(estacionamento);

            return _mapper.Map<EstacionamentoConfigResponseDTO>(estacionamento);
        }
    }
}