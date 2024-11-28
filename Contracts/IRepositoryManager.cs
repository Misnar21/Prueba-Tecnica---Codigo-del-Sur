using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IRepositoryManager
	{
		IUserRepository UserRepository { get; }
		void Save();
		Task SaveAsync();
	}
}
