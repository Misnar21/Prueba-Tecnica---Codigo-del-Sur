using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seed
{
	internal class UserSeed : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
				new User
				{
					Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
					Username = "admin",
					Password = "admin",
				}
			);
		}
	}
}
