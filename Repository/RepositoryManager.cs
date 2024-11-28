using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext _repositoryContext;
		private readonly Lazy<IUserRepository> _userRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			_repositoryContext = repositoryContext;

			_userRepository = new Lazy<IUserRepository>(() => new
				UserRepository(repositoryContext));
		}

		public IUserRepository UserRepository => _userRepository.Value;

		public void Save() => _repositoryContext.SaveChanges();

		public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
	}
}
