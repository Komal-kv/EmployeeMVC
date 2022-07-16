using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public void AddEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployees();
    }   
}
