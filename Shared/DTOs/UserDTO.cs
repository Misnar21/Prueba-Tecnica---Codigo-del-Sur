using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
	public record UserDTO(Guid Id, string UserName);

	public record UserForCreationDTO(string UserName, string Password);
}
