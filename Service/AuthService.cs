using AutoMapper;
using Contracts;
using Entities;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DTOs;
using System.Security.Claims;
using System.Text;

namespace Service
{
	internal sealed class AuthService : IAuthService
	{
		private readonly IRepositoryManager _repository;
		private readonly IConfiguration _configuration;
		private readonly IServiceManager _serviceManager;
		private readonly IMapper _mapper;

		public AuthService(IRepositoryManager repository, IConfiguration configuration, IServiceManager serviceManager, IMapper mapper)
		{
			_repository = repository;
			_configuration = configuration;
			_serviceManager = serviceManager;
			_mapper = mapper;
		}

		public Task<string> AuthenticateUserAsync(UserDTO userLogin)
		{
			throw new NotImplementedException();
		}

		public Task<UserForCreationDTO> RegisterUserAsync(UserForCreationDTO userRegistration)
		{
			throw new NotImplementedException();
		}
	}
}
