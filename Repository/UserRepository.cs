using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	internal class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

		public void CreateUser(User user) => Create(user);

		public async Task<bool> ExistsByUsernameAsync(string username)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public async Task<User?> GetUserByIdAsync(Guid userId, bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public async Task<User?> GetUserByUsernameAsync(string username, bool trackChanges)
		{
			throw new NotImplementedException();
		}
	}
}
