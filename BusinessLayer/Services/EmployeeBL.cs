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

        public void DeleteEmployee(int? id)
        {
            try
            {
                this.employeeRL.DeleteEmployee(id);
            }
            catch(Exception e)
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

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return this.employeeRL.GetEmployeeData(id);
            }
            catch(Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                this.employeeRL.UpdateEmployee(employee);
            }
            catch(Exception e)
            {

                throw e;
            }
        }
    }
}
