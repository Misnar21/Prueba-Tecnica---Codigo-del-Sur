using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
	internal sealed class WeatherApiService : IWeatherApiService
	{
		private readonly IMapper _mapper;
		public WeatherApiService(IMapper mapper)
		{
			_mapper = mapper;
		}

	}
}
