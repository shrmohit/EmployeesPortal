using EmployeesPortal.Models.Entities;
using EmployeesPortal.Repositories.Interfaces;
using EmployeesPortal.Services.Interfaces;

namespace EmployeesPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public async Task CreateEmployeeAsync(Employee employee)
        {
            await repo.AddAsync(employee);
        }
        
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await repo.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            await repo.DeleteAsync(employee);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var empbyid = await repo.GetByIdAsync(id);
            if (empbyid == null)
            {
                throw new Exception("Employee not found");
            }

            return empbyid;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await repo.GetAllAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var existEmployee = await repo.GetByIdAsync(employee.Id);
            if (existEmployee == null)
            {
                throw new Exception("Employee not found");
            }

            await repo.UpdateAsync(employee);
        }
    }
}
