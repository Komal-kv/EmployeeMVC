using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration configuration;
        public EmployeeRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // To add New Employee Record
        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@profileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@startDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@notes", employee.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {

                throw ex;
            }
        }

        // To View All Employee Details
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> lstemployee = new List<EmployeeModel>();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmployeePayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();

                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = Convert.ToString(rdr["Name"]);
                        employee.ProfileImage = Convert.ToString(rdr["profileImage"]);
                        employee.Gender = Convert.ToString(rdr["Gender"]);
                        employee.Department = Convert.ToString(rdr["Department"]);
                        employee.Salary = Convert.ToInt32(rdr["salary"]);
                        employee.StartDate = Convert.ToDateTime(rdr["startDate"]);
                        employee.Notes = Convert.ToString(rdr["notes"]);

                        lstemployee.Add(employee);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch(Exception ex)
            {

                throw ex;
            }
        }
    }
}
