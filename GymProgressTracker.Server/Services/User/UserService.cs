using AutoMapper;
using GymProgressTracker.Server.Models.DTO.User;
using GymProgressTracker.Server.Repositories.User;
using System.Security.Cryptography;
using System.Text;

namespace GymProgressTracker.Server.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public async Task<UserDTO> LoginAsync(LoginUserDTO loginUserDTO)
        {
            var user = await _userRepository.GetByEmailAndPassword(loginUserDTO.Email, loginUserDTO.Password);

            if (user == null)
            {
                return null;
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> RegisterAsync(AddUserDTO userDTO)
        {
            var isEmailTaken = await _userRepository.IsEmailTaken(userDTO.Email);
            if (isEmailTaken)
            {
                return null;
            }

            var user = _mapper.Map<Models.Domain.User>(userDTO);
            user.Password = HashPassword(userDTO.Password);

            await _userRepository.AddAsync(user);

            var userDTOResult = _mapper.Map<UserDTO>(user);

            return userDTOResult;
        }
    }
}
