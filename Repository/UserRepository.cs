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
			return await FindByCondition(u => u.Username.Equals(username), false)
						 .AnyAsync();
		}

		public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges)
		{
			return await FindAll(trackChanges)
						 .OrderBy(u => u.Username)
						 .ToListAsync();
		}

		public async Task<User?> GetUserByIdAsync(Guid userId, bool trackChanges)
		{
			return await FindByCondition(u => u.Id == userId, trackChanges)
						 .SingleOrDefaultAsync();
		}

		public async Task<User?> GetUserByUsernameAsync(string username, bool trackChanges)
		{
			return await FindByCondition(u => u.Username.Equals(username), trackChanges)
						 .SingleOrDefaultAsync();
		}
	}
}
