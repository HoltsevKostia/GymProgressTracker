using GymProgressTracker.Server.Models.DTO.User;

namespace GymProgressTracker.Server.Services.User
{
    public interface IUserService
    {
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<(string Token, UserDTO User)?> RegisterAsync(AddUserDTO userDTO);
        Task<(string Token, UserDTO User)?> LoginAsync(LoginUserDTO loginUserDTO);
        string HashPassword(string password);
    }
}
