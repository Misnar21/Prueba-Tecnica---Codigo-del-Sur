using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Service.Contracts
{
	public interface IAuthService
	{
		Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
	}
}
