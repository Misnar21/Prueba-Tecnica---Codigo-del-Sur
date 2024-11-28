using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IServiceManager _service;

		public AuthController(IServiceManager service) => _service = service;

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserDTO userLogin)
		{
			var token = await _service.AuthService.AuthenticateUserAsync(userLogin);

			if (token == null)
			{
				return Unauthorized("Invalid username or password.");
			}

			return Ok(new { Token = token });
		}
	}
}
