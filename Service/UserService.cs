using AutoMapper;
using Contracts;
using Service.Contracts;

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

	}
}
