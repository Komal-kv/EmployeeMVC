using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        // Show employee list
        public IActionResult ListOfEmployee()
        {
            List<EmployeeModel> allEmployees = new List<EmployeeModel>();
            allEmployees = employeeBL.GetAllEmployees().ToList();
            return View(allEmployees);
        }

        // Add new employee

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeBL.AddEmployee(employee);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }
    }
}
