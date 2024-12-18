using Microsoft.AspNetCore.Mvc;
using Presentation;
using PruebaCodigoDelSur.Extensions;
using Shared.DTOs;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Extension services
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.AddHttpClient();
builder.Services.ConfigureCors();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureControllers();
builder.Services.AddAutoMapper(typeof(Program));

// Other services
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseSwagger();
app.UseSwaggerUI(s =>
{
	s.SwaggerEndpoint("/swagger/v1/swagger.json", "Endpoints");
});


app.UseHttpsRedirection();


app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});


app.Run();