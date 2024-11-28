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
	[Route("api/users")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IServiceManager _service;

		public UserController(IServiceManager service) => _service = service;

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] UserForCreationDTO userForCreationDto)
		{
			if (userForCreationDto == null)
				return BadRequest("User data is null");

			var createdUser = await _service.UserService.CreateUserAsync(userForCreationDto);

			return CreatedAtRoute("GetUserById", new { id = createdUser.Id }, createdUser);
		}
	}
}
