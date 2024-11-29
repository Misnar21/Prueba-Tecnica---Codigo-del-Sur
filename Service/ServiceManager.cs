using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IUserService> _userService;
		private readonly Lazy<IAuthService> _authService;
		private readonly Lazy<IWeatherApiService> _weatherService;
		private readonly Lazy<IPreferencesService> _preferencesService;
		public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration, UserManager<User> userManager)
		{
			_userService = new Lazy<IUserService>(() => new
				UserService(repositoryManager, mapper));

			_weatherService = new Lazy<IWeatherApiService>(() => new
				WeatherApiService(mapper));

			_authService = new Lazy<IAuthService>(() => new
				AuthService(repositoryManager, configuration, mapper, userManager));

			_preferencesService = new Lazy<IPreferencesService>(() => new
				PreferencesService(repositoryManager, mapper));
		}
		public IUserService UserService => _userService.Value;
		public IWeatherApiService WeatherApiService => _weatherService.Value;
		public IAuthService AuthService => _authService.Value;
		public IPreferencesService PreferencesService => throw new NotImplementedException();
	}
}
