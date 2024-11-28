using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
	internal sealed class PreferencesService : IPreferencesService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;
		public PreferencesService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

	}
}
