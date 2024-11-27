using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class User
	{
		[Column("UserId")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Username is required.")]
		[MaxLength(30, ErrorMessage = "Maximum length for the username is 30 characters.")]
		public required string Username { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		[MaxLength(50, ErrorMessage = "Maximum length for the password is 50 characters.")]
		public required string Password { get; set; }

	}
}
