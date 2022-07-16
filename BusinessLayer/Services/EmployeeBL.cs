using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                 this.employeeRL.AddEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return this.employeeRL.GetAllEmployees();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
