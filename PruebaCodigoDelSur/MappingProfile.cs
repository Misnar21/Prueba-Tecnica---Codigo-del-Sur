using AutoMapper;
using Entities;
using Shared.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaCodigoDelSur
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserForCreationDTO>();

			CreateMap<User, UserDTO>();

			CreateMap<UserForCreationDTO, User>();

			CreateMap<UserDTO, User>();

			CreateMap<UserForRegistrationDto, User>();

		}
	}
}
