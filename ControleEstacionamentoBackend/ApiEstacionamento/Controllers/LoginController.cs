using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstacionamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstacionamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AuthService authService;
        public LoginController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] DTOs.LoginRequestDTO loginRequestDTO)
        {
            var loginResponse = await authService.LoginAsync(loginRequestDTO);
            return Ok(loginResponse);
        }
    }
}