using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DTOs;

namespace Service
{
	internal sealed class UserService : IUserService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;
		public UserService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public Task<UserDTO> CreateUserAsync(UserForCreationDTO user)
		{
			throw new NotImplementedException();
		}

		public Task<UserDTO> GetUserByUsernameAsync(string username)
		{
			throw new NotImplementedException();
		}
	}
}
