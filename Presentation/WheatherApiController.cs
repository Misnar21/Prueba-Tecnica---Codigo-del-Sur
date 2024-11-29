using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
	[Authorize]
	[Route("api/weatherApi")]
	public class WheatherApiController : ControllerBase
	{
		private readonly IServiceManager _service;

		public WheatherApiController(IServiceManager service) => _service = service;

		[HttpGet]
		public async Task<IActionResult> GetWeatherData([FromQuery] string city)
		{
			throw new NotImplementedException();
		}
	}
}
