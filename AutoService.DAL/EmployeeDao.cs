using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class EmployeeDao : IEmployeeDao
    {
        private SqlConnection _connection = DbConnection.GetSqlConnection();
        
        public Employee Create(string name, string lastName, double salary)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "insert into employee (name, last_name, salary) values (@name, @lastName, @salary)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = "select * from employee where name = @name and last_name = @lastName and salary = @salary";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@salary", salary);
                var reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        LastName = (string) reader["last_name"],
                        Salary = (double) reader["salary"]
                    };
                    return employee;
                }

                throw new Exception("Error");//todo
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = new List<Employee>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from employee";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        LastName = (string) reader["last_name"],
                        Salary = (double) reader["salary"]
                    };
                    result.Add(employee);
                }
            }
            return result.AsEnumerable();
        }

        public int Delete(long id)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from employee where id = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}