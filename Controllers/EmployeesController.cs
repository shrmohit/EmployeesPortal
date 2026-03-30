using Microsoft.AspNetCore.Mvc;
using EmployeesPortal.Models.Entities;
using EmployeesPortal.Services.Interfaces;

namespace EmployeesPortal.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService service;

        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> EmployeesData()
        {
            var employees = await service.GetEmployeesAsync();
            return View(employees);
        }

        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            await service.CreateEmployeeAsync(employee);
            TempData["Message"] = "Employee Successfully Create";
            return RedirectToAction("EmployeesData");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await service.GetEmployeeByIdAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            await service.DeleteEmployeeAsync(id);
            TempData["Message"] = "Employee Delete Successfully";
            return RedirectToAction("EmployeesData");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var updateEmployee = await service.GetEmployeeByIdAsync(id);
            return View(updateEmployee);
        }

        public async Task<IActionResult> UpdateById(Employee employee)
        {
            await service.UpdateEmployeeAsync(employee);
            TempData["Message"] = "Employee Update Successfully";
            return RedirectToAction("EmployeesData");

        }

        [HttpGet]
        public async Task<IActionResult> EmployeeDetails(int id)
        {
            var empDetails = await service.GetEmployeeByIdAsync(id);
            return View(empDetails);
        }
    }
}
