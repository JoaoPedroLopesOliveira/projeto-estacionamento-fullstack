using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanoController : ControllerBase
    {

        private readonly IPlanoService _planoService;
        public PlanoController(IPlanoService planoService)
        {
            _planoService = planoService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlano([FromBody] PlanoCreateDTO planoCreateDTO)
        {
            var plano = await _planoService.CreatePlanoAsync(planoCreateDTO);
            return CreatedAtAction(nameof(GetPlanoById), new {id = plano.Id}, plano);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanoById(int id)
        {
            var plano = await _planoService.GetPlanoByIdAsync(id);
            if(plano == null)
            {
                throw new Exception("Plano não encontrado");
            }
            return Ok(plano);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanosAsync()
        {
            var planos = _planoService.GetAllPlanosAsync();
            return Ok(planos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlano(int id, [FromBody] PlanoUpdateDTO planoUpdateDTO)
        {
            var updatedPlano = await _planoService.UpdatePlanoAsync(id,planoUpdateDTO);
            if (updatedPlano == null)
            {
                throw new Exception("Plano não encontrado");
            }
            return Ok(updatedPlano);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlano(int id)
        {
            var deleted = await _planoService.DeletePlanoAsync(id);
            if (!deleted)
            {
                throw new Exception("Plano não encontrado");
            }
            return NoContent();
        }
    }
}