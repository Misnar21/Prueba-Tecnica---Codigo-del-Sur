using Microsoft.AspNetCore.Identity;
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
		public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
		{
			if (user == null) return BadRequest("User cant be null");

			if (!await _service.AuthService.ValidateUser(user)) return Unauthorized();
			
			return Ok(new
			{
				Token = await _service.AuthService.CreateToken()
			});
		}


		[HttpPost("register")]
		public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
		{
			IdentityResult result = await _service.AuthService.RegisterUser(userForRegistration);

			if (result is null) return BadRequest("Result is null");

			if (!result.Succeeded)
			{	
				foreach (var error in result.Errors)
				{
					ModelState.TryAddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}
			return Ok("User was registred correctly!");
		}

	}
}
