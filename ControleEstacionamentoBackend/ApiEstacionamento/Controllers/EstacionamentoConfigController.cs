using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using ApiEstacionamento.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoConfigController : ControllerBase
    {

        private readonly IEstacionamentoService _estacionamentoService;
        public EstacionamentoConfigController (IEstacionamentoService estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstacionamentoById(int id)
        {
            var estacionamento = await _estacionamentoService.GetEstacionamentoByIdAsync(id);
            if(estacionamento == null)
            {
                throw new Exception("estacionamento não encontrado.");
            }
            return Ok(estacionamento);
        }
        [HttpGet]
        public async Task<IActionResult> GetEstacionamentos()
        {
            var estacionamentos = await _estacionamentoService.GetEstacionamentoAsync();
            return Ok(estacionamentos);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEstacionamento(EstacionamentoConfigCreateDTO estacionamentoConfigCreateDTO)
        {
            var estacionamento = await _estacionamentoService.CreateEStacionamentoAsync(estacionamentoConfigCreateDTO);
            return CreatedAtAction(nameof(GetEstacionamentoById), new {id = estacionamento.Id}, estacionamento);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstacionamento(int id, EstacionamentoConfigUpdateDTO estacionamentoConfigUpdateDTO)
        {
            var estacionamentoUpdate = await _estacionamentoService.UpdateEstacionamento(id, estacionamentoConfigUpdateDTO);
            if(estacionamentoUpdate == null)
            {
                throw new Exception("estacionamento não encontrado.");
            }
            return Ok(estacionamentoUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstacionamento(int id)
        {
            var deleted = await _estacionamentoService.DeleteEstacionamento(id);
            if (!deleted)
            {
                throw new Exception("estacionamento não encontrado.");
            }
            return NoContent();
        }

    }
}