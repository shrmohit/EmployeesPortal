using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeesPortal.Models;

namespace EmployeesPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



     
    }
}
