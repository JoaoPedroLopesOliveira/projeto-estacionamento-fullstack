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
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }
       [HttpPost]
        public async Task<IActionResult> CreateVeiculo([FromBody] VeiculoCreateDTO veiculoCreateDTO)
        {
            var veiculo = await _veiculoService.CreateVeiculoAsync(veiculoCreateDTO);
            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVeiculo(int id, [FromBody] VeiculoUpdateDTO veiculoUpdateDTO)
        {
            var updatedVeiculo = await _veiculoService.UpdateVeiculoAsync(id, veiculoUpdateDTO);
            if (updatedVeiculo == null)
            {
                return NotFound();
            }
            return Ok(updatedVeiculo);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var veiculos = await _veiculoService.GetAllVeiculosAsync();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeiculoById(int id)
        {
            var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _veiculoService.DeleteVeiculoByIdAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

    }
}