using GymProgressTracker.Server.Models.DTO.User;
using GymProgressTracker.Server.Repositories.Repository;

namespace GymProgressTracker.Server.Repositories.User
{
    public interface IUserRepository : IRepository<Models.Domain.User>
    {
        Task<Models.Domain.User> GetByEmailAndPassword(string email, string password);
        Task<bool> IsEmailTaken(string email);
    }
}
