using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
	[Route("api/preferences")]
	[ApiController]
	public class PreferencesController : ControllerBase
	{
		private readonly IServiceManager _service;

		public PreferencesController(IServiceManager service) => _service = service;
	}
}
