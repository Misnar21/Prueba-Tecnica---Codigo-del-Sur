using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.DTOs
{
	public record UserDTO(Guid Id, string Username, string Password);

	public record UserForCreationDTO(string Username, string Password);

	public record UserForRegistrationDto
	{
		public string? FirstName { get; init; }
		public string? LastName { get; init; }
		[Required(ErrorMessage = "Username is required")]
		public string? UserName { get; init; }
		[Required(ErrorMessage = "Password is required")]
		public string? Password { get; init; }
		public string? Email { get; init; }
		public string? PhoneNumber { get; init; }
		//[JsonIgnore]
		//public ICollection<string>? Roles { get; init; }
	}

	public record UserForAuthenticationDto
	{
		[Required(ErrorMessage = "User name is required")]
		public string? UserName { get; init; }
		[Required(ErrorMessage = "Password name is required")]
		public string? Password { get; init; }
	}
}
