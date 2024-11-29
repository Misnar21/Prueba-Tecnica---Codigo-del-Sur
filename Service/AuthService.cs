using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DTOs;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Service
{
	internal sealed class AuthService : IAuthService
	{
		private readonly IRepositoryManager _repository;
		private readonly IConfiguration _configuration;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private User? _user;

		public AuthService(IRepositoryManager repository, IConfiguration configuration, IMapper mapper, UserManager<User> userManager)
		{
			_repository = repository;
			_configuration = configuration;
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<string> CreateToken()
		{
			var signingCredentials = GetSigningCredentials();
			var claims = await GetClaims();
			var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
			return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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

		public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
		{
			_user = await _userManager.FindByNameAsync(userForAuth.UserName);

			var result = (_user != null && await _userManager.CheckPasswordAsync(_user,userForAuth.Password));

			if (!result) throw new Exception("Authentication failed, wrong username or password.");

			return result;

		}

		private SigningCredentials GetSigningCredentials()
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
			var secret = new SymmetricSecurityKey(key);
			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}
		private async Task<List<Claim>> GetClaims()
		{
			var claims = new List<Claim>
			 {
				new Claim(ClaimTypes.Name, _user.UserName)
			 };
			var roles = await _userManager.GetRolesAsync(_user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}
			return claims;
		}

		private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,List<Claim> claims)
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var tokenOptions = new JwtSecurityToken
			(
				issuer: jwtSettings["validIssuer"],
				audience: jwtSettings["validAudience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
				signingCredentials: signingCredentials
			);
			return tokenOptions;
		}

	}
}
