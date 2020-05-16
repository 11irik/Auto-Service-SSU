using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class ServiceDao : IServiceDao
    {
        private SqlConnection _connection;

        public ServiceDao()
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());
        }
        
        public Service Create(string name, double price)
        {
            using (_connection)
            {
                _connection.Open();
                try
                {
                    string sql =
                        "insert into service_price (name, price) values (@name, @price)";
                    SqlCommand cmd = new SqlCommand(sql, _connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    sql = "select * from service where name = @name";
                    cmd = new SqlCommand(sql, _connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Service service = new Service()
                        {
                            Id = (long) reader["id"],
                            Name = (string) reader["name"],
                            Price = (double) reader["price"]
                        };
                        return service;
                    }
                }
                catch (Exception e)
                {
                    
                }
                return new Service();
            }
        }

        public IEnumerable<Service> GetAll()
        {
            var result = new List<Service>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from service";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Service service = new Service()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        Price = (double) reader["price"]
                    };
                    result.Add(service);
                }
            }
            return result.AsEnumerable();
        }

        public int Delete(long id)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from service where id = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}