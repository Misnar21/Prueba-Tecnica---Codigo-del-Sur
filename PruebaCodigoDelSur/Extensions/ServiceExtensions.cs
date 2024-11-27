using Microsoft.EntityFrameworkCore;
using Repository;

namespace PruebaCodigoDelSur.Extensions
{
	public static class ServiceExtensions
	{
		// TODO Agregar seguridad del lado de los CORS
		public static void ConfigureCors(this IServiceCollection services) =>
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyHeader()
						   .AllowAnyMethod()
						   .AllowAnyHeader();
				});
			});

		public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
			services.AddDbContext<RepositoryContext>(opts =>
				opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
	}
}
