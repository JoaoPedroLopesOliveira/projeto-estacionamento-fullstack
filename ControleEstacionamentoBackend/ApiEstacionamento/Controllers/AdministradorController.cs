using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.DTOs;
using ApiEstacionamento.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorService _administradorService;
        public AdministradorController(IAdministradorService administradorService)
        {
            _administradorService = administradorService;
        }

        [HttpPost]
        [Authorize(Roles = "MASTER")]
        public async Task<IActionResult> CreateAdministrador(AdministradorCreateDTO administradorCreateDTO)
        {
            var administrador = await _administradorService.CreateAdministradorAsync(administradorCreateDTO);
            return CreatedAtAction(nameof(GetAdministradorById), new { id = administrador.Id }, administrador);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "MASTER")]
        public async Task<IActionResult> UpdateAdministrador(int id, [FromBody] AdministradorUpdateDTO administradorUpdateDTO)
        {   
            var updatedAdministrador = await _administradorService.UpdateAdministradorAsync(id, administradorUpdateDTO);
            if (updatedAdministrador == null)
            {
                throw new Exception("Administrador não encontrado.");
            }
            return Ok(updatedAdministrador);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdministradores()
        {
            var administradores = await _administradorService.GetAllAdministradoresAsync();
            return Ok(administradores);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdministradorById(int id)
        {
            var administrador = await _administradorService.GetAdministradorByIdAsync(id);
            if (administrador == null)
            {
                throw new Exception("Administrador não encontrado.");
            }
            return Ok(administrador);

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "MASTER")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var deleted = await _administradorService.DeleteAdministradorByIdAsync(id);
            if (!deleted)
            {
                throw new Exception("Administrador não encontrado.");
            }
            return NoContent();
        }
    }
}