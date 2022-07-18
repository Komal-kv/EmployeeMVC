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

        //For adding new employee

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

        //To delete the particular employee
        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.GetEmployeeData(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("ListOfEmployee");
        }

        //For updating employee details
        [HttpGet]
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployee(employee);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }
    }
}
