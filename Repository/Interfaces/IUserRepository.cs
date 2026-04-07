using EmployeesPortal.Models.Entities;

namespace EmployeesPortal.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAync(User user);
    }
}
