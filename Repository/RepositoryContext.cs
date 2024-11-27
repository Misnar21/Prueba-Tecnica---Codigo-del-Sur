using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions options) : base(options) { }

		// El encargado del Seed inicial de la BD
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserSeed());
		}

		public DbSet<User> Users { get; set; }
	}
}
