using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seed
{
	public class RolesSeed : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			 builder.HasData(
				 new IdentityRole
				 {
					 Name = "Administrator",
					 NormalizedName = "ADMINISTRATOR"
				 });
		}

	}
}
