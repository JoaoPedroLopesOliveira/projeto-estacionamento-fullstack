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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetClienteByid(int id)
        {
            var cliente = await _clienteService.GetClienteAsync(id);
            if(cliente == null)
            {
                throw new Exception("cliente não encontrado");
            }
            return Ok(cliente);
        }
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteService.DeleteCliente(id);
            if (!cliente)
            {
                throw new Exception("Cliente não encontrado.");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteUpdateDTO clienteUpdateDTO)
        {
            var cliente = _clienteService.UpdateClienteAsync(id, clienteUpdateDTO);
            return Ok(cliente);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCliente ([FromBody] ClienteCreateDTO clienteCreateDTO)
        {
            var cliente = _clienteService.CreateClienteAsync(clienteCreateDTO);
            return CreatedAtAction(nameof(GetClienteByid), new {id = cliente.Id}, cliente);
        }
    }
}