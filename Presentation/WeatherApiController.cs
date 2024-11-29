using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Presentation
{
	[Route("api/weatherApi")]
	public class WeatherApiController : ControllerBase
	{
		private readonly IServiceManager _service;
		private readonly HttpClient _httpClient;

		public WeatherApiController(IServiceManager service, HttpClient httpClient)
		{
			_service = service;
			_httpClient = httpClient;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetWeatherData([FromQuery] double lat, [FromQuery] double lon)
		{
			string apiKey = "94aca3368d421365a7e2a74772efc81f";
			var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}";

			try
			{
				var response = await _httpClient.GetAsync(apiUrl);

				if (!response.IsSuccessStatusCode) return BadRequest("Error al obtener datos del clima.");

				WeatherResponse weatherData = await response.Content.ReadFromJsonAsync<WeatherResponse>();

				if (weatherData == null) return NotFound("No hay datos del clima para esa lat y lon. Prueba numeros cercanos a 20.0");

				return Ok(new
				{
					Latitude = weatherData.Coord.Lat,
					Longitude = weatherData.Coord.Lon,
					Temperature = weatherData.Main.Temp,
					Condition = weatherData.Weather?.FirstOrDefault()?.Description,
					Country = weatherData.Sys.Country,
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

	}
}
