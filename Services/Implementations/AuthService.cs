using EmployeesPortal.Data;
using EmployeesPortal.DTOs;
using EmployeesPortal.Models.Entities;
using EmployeesPortal.Repository.Interfaces;
using EmployeesPortal.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EmployeesPortal.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository UserRepository;
        private readonly IConfiguration Config;

        public AuthService(IUserRepository userRepository , IConfiguration config)
        {
            UserRepository = userRepository;
            Config = config;
        }


        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await UserRepository.GetUserByEmailAsync(loginDto.Email);

            // ✅ Null check
            if (user == null)
            {
                return "User not found.";
            }

            if (user.Email != loginDto.Email || user.Password != loginDto.Password)
            {
                return "Invalid email or password.";
            }

            return GenerateToken(user);
        }

        public string GenerateToken(User user)
        {

            // step 1 -  create claims based on user information 
            // claim is used to store user information in token 
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName)
            };

            // step 2 - ise key(key ) se token sign hota hai
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"] ?? ""));

            // step 3 - singing credentials create karna
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // step 4 - token create karna hai
            var token = new JwtSecurityToken(
                issuer: Config["Jwt:Issuer"],
                audience: Config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            // step 5 - token ko string me convert karna hai
            return new JwtSecurityTokenHandler().WriteToken(token);



        }

        public async Task<string> RegisterDtoAsync(RegisterDto registerDto)
        {
            var existingUser = await UserRepository.GetUserByEmailAsync(registerDto.Email);

            if (existingUser != null)
            {
                return "User with this email already exists.";
            }

            var adduser = new User {
                Email = registerDto.Email,
                FullName = registerDto.FullName,
                Password = registerDto.Password,
                PhoneNumber = registerDto.PhoneNumber,
            };

            await UserRepository.AddUserAync(adduser);
            return "User registered successfully.";
        }

       
    }
}
