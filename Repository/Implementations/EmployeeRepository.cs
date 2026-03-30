using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using EmployeesPortal.Data;
using EmployeesPortal.Models.Entities;
using EmployeesPortal.Repositories.Interfaces;

namespace EmployeesPortal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();

        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await context.Employees.FindAsync(id);
        }


        public async Task UpdateAsync(Employee emp)
        {
            var existingEmp = await context.Employees.FindAsync(emp.Id);

            if (existingEmp == null)
                return;

            existingEmp.PhoneNumber = emp.PhoneNumber;
            existingEmp.Salary = emp.Salary;
            existingEmp.Email = emp.Email;
            existingEmp.Age = emp.Age;
            existingEmp.Department = emp.Department;
            existingEmp.EmployeeName = emp.EmployeeName;
            existingEmp.EmployeeId = emp.EmployeeId;
            existingEmp.Gender = emp.Gender;


            await context.SaveChangesAsync();
        }
    }
}
