using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Identity;
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
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public AuthService(IRepositoryManager repository, IConfiguration configuration, IMapper mapper, UserManager<User> userManager)
		{
			_repository = repository;
			_configuration = configuration;
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
		{
			if (userForRegistration is null) throw new Exception("Body is null");

			var user = _mapper.Map<User>(userForRegistration);

			var result = await _userManager.CreateAsync(user,userForRegistration.Password);

			//if (result.Succeeded)
			//	await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

			return result;
		}

	}
}
