using Lab_4_App.model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Lab_4_App.repository
{
    public class EmployeeRespository
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString_ADO"].ConnectionString;

        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT EmployeeID, Name, Department, Position, Phone FROM Employees", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Department = reader.GetString(2),
                        Position = reader.GetString(3),
                        Phone = reader.GetString(4)
                    };
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Employees SET Name=@Name, Department=@Department, Position=@Position, Phone=@Phone WHERE EmployeeID=@EmployeeID", connection);
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@Phone", employee.Phone);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Employees (Name, Department, Position, Phone) VALUES (@Name, @Department, @Position, @Phone)", connection);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@Phone", employee.Phone);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Employees WHERE EmployeeID=@EmployeeID", connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
