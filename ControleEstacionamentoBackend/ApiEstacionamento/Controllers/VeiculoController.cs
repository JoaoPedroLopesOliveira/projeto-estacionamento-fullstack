using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
       //[Authorize(Roles = "MASTER,COMUM")]
        public async Task<IActionResult> CreateVeiculo([FromBody] VeiculoCreateDTO veiculoCreateDTO)
        {
            var veiculo = await _veiculoService.CreateVeiculoAsync(veiculoCreateDTO);
            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "MASTER,COMUM")]
        public async Task<IActionResult> UpdateVeiculo(int id, [FromBody] VeiculoUpdateDTO veiculoUpdateDTO)
        {
            var updatedVeiculo = await _veiculoService.UpdateVeiculoAsync(id, veiculoUpdateDTO);
            if (updatedVeiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
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
                throw new Exception("Veículo não encontrado.");
            }
            return Ok(veiculo);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "MASTER,COMUM")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _veiculoService.DeleteVeiculoByIdAsync(id);
            if (!deleted) throw new Exception("Veículo não encontrado.");
            return NoContent();
        }

    }
}