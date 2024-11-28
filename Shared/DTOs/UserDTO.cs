using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
	public record UserDTO(Guid Id, string Username, string Password);

	public record UserForCreationDTO(string Username, string Password);
}
