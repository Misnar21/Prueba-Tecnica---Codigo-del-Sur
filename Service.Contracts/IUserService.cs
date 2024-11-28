using Entities;
using Shared.DTOs;

namespace Service.Contracts
{
	public interface IUserService
	{
		Task<UserDTO> GetUserByUsernameAsync(string username);
		Task<UserDTO> CreateUserAsync(UserForCreationDTO user);
	}
}
