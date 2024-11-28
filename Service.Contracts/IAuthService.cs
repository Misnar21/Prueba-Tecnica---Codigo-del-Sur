using Shared.DTOs;

namespace Service.Contracts
{
	public interface IAuthService
	{
		Task<UserForCreationDTO> RegisterUserAsync(UserForCreationDTO userRegistration);
		Task<string> AuthenticateUserAsync(UserDTO userLogin);
	}
}
