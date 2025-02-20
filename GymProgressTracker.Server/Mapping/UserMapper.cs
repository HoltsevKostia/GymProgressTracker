using AutoMapper;
using GymProgressTracker.Server.Models.Domain;
using GymProgressTracker.Server.Models.DTO.User;

namespace GymProgressTracker.Server.Mapping
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>();

            CreateMap<User, AddUserDTO>();

            CreateMap<User, LoginUserDTO>();
        }
    }
}
