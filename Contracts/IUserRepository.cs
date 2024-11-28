using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IUserRepository
	{
		Task<User?> GetUserByIdAsync(Guid userId, bool trackChanges);
		Task<User?> GetUserByUsernameAsync(string username, bool trackChanges);
		void CreateUser(User user);
		Task<bool> ExistsByUsernameAsync(string username);
	}
}
