using EmployeesPortal.DTOs;

namespace EmployeesPortal.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterDtoAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
