using GymProgressTracker.Server.Models.DTO.User;

namespace GymProgressTracker.Server.Services.User
{
    public interface IUserService
    {
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<UserDTO> RegisterAsync(AddUserDTO userDTO);
        Task<UserDTO> LoginAsync(LoginUserDTO userDTO);
        string HashPassword(string password);
    }
}
