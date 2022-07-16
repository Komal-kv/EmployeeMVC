using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public void AddEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployees();
    }
}
