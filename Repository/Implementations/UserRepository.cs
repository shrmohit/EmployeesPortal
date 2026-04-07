using EmployeesPortal.Data;
using EmployeesPortal.Models.Entities;
using EmployeesPortal.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesPortal.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddUserAync(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);

        }
    }
}
