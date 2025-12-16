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
    public class PlanoService : IPlanoService
    {

        private readonly EstacionamentoContext _contexto;
        private readonly Mapper _mapper; 

        public PlanoService(EstacionamentoContext context, IMapper mapper)
        {
            _contexto = context;
            _mapper = (Mapper)mapper;
        }
        public async Task<PlanoResponseDTO> CreatePlanoAsync(PlanoCreateDTO planoCreateDTO)
        {
            var plano = _mapper.Map<Plano>(planoCreateDTO);
            _contexto.Planos.Add(plano);
            await _contexto.SaveChangesAsync();
            return _mapper.Map<PlanoResponseDTO>(plano);
        }

        public async Task<List<PlanoResponseDTO>> GetAllPlanosAsync()
        {
            var planos = await _contexto.Planos.ToListAsync();
            return _mapper.Map<List<PlanoResponseDTO>>(planos);
        }

        public async Task<PlanoResponseDTO> GetPlanoByIdAsync(int idPlano)
        {
            var plano = await _contexto.Planos.FindAsync(idPlano);
            if (plano == null)
            {
                return null;
            }
            return _mapper.Map<PlanoResponseDTO>(plano);
        }

        public async Task<PlanoResponseDTO> UpdatePlanoAsync(int id,PlanoUpdateDTO planoUpdateDTO)
        {
            var plano = await _contexto.Planos.FindAsync(id);
            if(plano == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(planoUpdateDTO.Nome))
            {
                plano.Nome = planoUpdateDTO.Nome;
            }
            if (!string.IsNullOrEmpty(planoUpdateDTO.Tipo))
            {
                plano.Tipo = planoUpdateDTO.Tipo;
            }
            if (planoUpdateDTO.Preco != (decimal)0.00)
            {
                plano.Preco = planoUpdateDTO.Preco;
            }
            if (planoUpdateDTO.QuantidadeVeiculosPermitidos != 0)
            {
                plano.QuantidadeVeiculosPermitidos= planoUpdateDTO.QuantidadeVeiculosPermitidos;
            }
            if (!string.IsNullOrEmpty(planoUpdateDTO.Description))
            {
                plano.Description = planoUpdateDTO.Description;
            }
            await _contexto.SaveChangesAsync();
            return _mapper.Map<PlanoResponseDTO>(plano);
        }
        public async Task<bool> DeletePlanoAsync(int id)
        {
            var plano = await _contexto.Planos.FindAsync(id);
            if(plano == null)
            {
                return false;
            }
            _contexto.Planos.Remove(plano);
            return true;
        }
    }
}