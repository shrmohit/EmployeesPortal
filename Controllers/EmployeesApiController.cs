using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EmployeesPortal.Models.Entities;
using EmployeesPortal.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EmployeesPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly IEmployeeService service;
        private readonly ILogger<EmployeesApiController> logger;

        public EmployeesApiController(IEmployeeService service , ILogger<EmployeesApiController> logger)
        {
            this.service = service;
            this.logger = logger;

        }

        

        [HttpPost("Create")]
        public async  Task<IActionResult> Create(Employee employee)
        {
            try 
            {
                await service.CreateEmployeeAsync(employee);
                return StatusCode(201, "Employee created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetAllEmployee")]
        [Authorize]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                logger.LogInformation("you are unauthorized");
                var employeelist = await service.GetEmployeesAsync();
                return Ok(employeelist);
            }
            catch
            {
                return BadRequest();

            }
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await service.GetEmployeeByIdAsync(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await service.DeleteEmployeeAsync(id);
                return Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> updateEmployee(Employee employee)
        {
            try
            {
                await service.UpdateEmployeeAsync(employee);
                return StatusCode(200, "update successfullly");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
