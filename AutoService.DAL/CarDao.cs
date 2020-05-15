using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class CarDao : ICarDao
    {
        private SqlConnection _connection;

        public CarDao()
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());
        }

        public Car Create(long clientId, string number)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "insert into car (client_id, number) values (@clientId, @number)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.Parameters.AddWithValue("@number", number);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                
                sql = "select * from car where number = @number";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@number", number);
                var reader = cmd.ExecuteReader();
                
                
                if (reader.Read())
                {
                    Car car = new Car()
                    {
                        Id = (long) reader["id"],
                        ClientId = (long) reader["client_id"],
                        Number = (string) reader["number"]
                    };
                    return car;
                }
                throw new Exception("Car with this number is already registered");
            }
            //todo check exception
        }

        public Car Get(string number)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "select * from car where number = @number";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@number", number);
                var reader = cmd.ExecuteReader();
                
                
                if (reader.Read())
                {
                    Car car = new Car()
                    {
                        Id = (long) reader["id"],
                        ClientId = (long) reader["client_id"],
                        Number = (string) reader["number"]
                    };
                    return car;
                }
                throw new Exception("Not found");
            }
        }

        public IEnumerable<Car> GetAll()
        {
            var result = new List<Car>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from car";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Car car = new Car()
                    {
                        Id = (long) reader["id"],
                        ClientId = (long) reader["client_id"],
                        Number = (string) reader["number"]
                    };
                    result.Add(car);
                }
            }
            return result.AsEnumerable();
        }

        public int Delete(string number)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from car where number = @number";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@number", number);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}