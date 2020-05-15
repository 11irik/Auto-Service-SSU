using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class CarPartDao : ICarPartDao
    {
        private SqlConnection _connection;

        public CarPartDao()
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());
        }
        
        public CarPart Create(string name, long manufacturerId, double price, int stock)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "insert into car_part (name, price, manufacturer_id, stock) values (@name, @price, @manufacturerId, @stock)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@manufacturerId", manufacturerId);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = "select * from car_part where name = @name and manufacturer_id = @manufacturerId";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@manufacturerId", manufacturerId);
                var reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    CarPart carPart = new CarPart()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        ManufacturerId = (long) reader["manufacturer_id"],
                        Stock = (int) reader["stock"],
                        Price = (double) reader["price"]
                    };
                    return carPart;
                }

                throw new Exception("Part with this name is already registered");
            }
        }

        public IEnumerable<CarPart> GetAll()
        {
            var result = new List<CarPart>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from car_part";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CarPart carPart = new CarPart()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        ManufacturerId = (long) reader["manufacturer_id"],
                        Stock = (int) reader["stock"],
                        Price = (double) reader["price"]
                    };
                    result.Add(carPart);
                }
            }
            return result.AsEnumerable();
        }

        public int Delete(long id)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from car_part where id = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}