using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Infrastructure.Persistence.DbContext;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using ApiEstacionamento.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApiEstacionamento.Domain.Interfaces.Repositories;

namespace ApiEstacionamento.Services
{
    public class PlanoService : IPlanoService
    {

        private readonly IPlanoRepositiorie _planoRepository;
        private readonly Mapper _mapper; 
        public PlanoService(IPlanoRepositiorie planoRepositiorie, IMapper mapper)
        {
            _planoRepository = planoRepositiorie;
            _mapper = (Mapper)mapper;
        }

        public async Task<PlanoResponseDTO> CreatePlanoAsync(PlanoCreateDTO planoCreateDTO)
        {
            var plano = _mapper.Map<Plano>(planoCreateDTO);
            await _planoRepository.CreateAsync(plano);
            return _mapper.Map<PlanoResponseDTO>(plano);
        }

        public async Task<bool> DeletePlanoAsync(int id)
        {
            var existente = await _planoRepository.GetByIdAsync(id);
            if (existente == null)
            {
                return false;
            }
            await _planoRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<PlanoResponseDTO>> GetAllPlanosAsync()
        {
            var planos = await _planoRepository.GetAllAsync();
            return _mapper.Map<List<PlanoResponseDTO>>(planos);
        }

        public async Task<PlanoResponseDTO> GetPlanoByIdAsync(int idPlano)
        {
            var plano = await _planoRepository.GetByIdAsync(idPlano);
            if (plano == null)
            {
                return null;
            }
            return _mapper.Map<PlanoResponseDTO>(plano);
        }

        public async Task<PlanoResponseDTO> UpdatePlanoAsync(int id, PlanoUpdateDTO planoUpdateDTO)
        {
            var plano = await _planoRepository.GetByIdAsync(id);
            if (plano == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(planoUpdateDTO.Description))
            {
                plano.Description = planoUpdateDTO.Description;
            }
            if (!string.IsNullOrEmpty(planoUpdateDTO.Nome))
            {
                plano.Nome = planoUpdateDTO.Nome;
            }
            if (!string.IsNullOrEmpty(planoUpdateDTO.Tipo))
            {
                plano.Tipo = planoUpdateDTO.Tipo;
            }
            if(planoUpdateDTO.Preco > 0)
            {
                plano.Preco = planoUpdateDTO.Preco;
            }
            if(planoUpdateDTO.QuantidadeVeiculosPermitidos > 0)
            {
                plano.QuantidadeVeiculosPermitidos = planoUpdateDTO.QuantidadeVeiculosPermitidos;
            }

            await _planoRepository.UpdateAsync(plano);
            return _mapper.Map<PlanoResponseDTO>(plano);
        }
    }
}