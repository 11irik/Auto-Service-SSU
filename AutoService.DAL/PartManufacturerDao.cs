using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class PartManufacturerDao : IPartManufacturerDao
    {
        private SqlConnection _connection = DbConnection.GetSqlConnection();

        public PartManufacturer Create(string name)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "insert into part_manufacturer (name) values (@name)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = "select * from part_manufacturer where name = @name";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                var reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    PartManufacturer partManufacturer = new PartManufacturer()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        Active = (bool) reader["active"]
                    };
                    return partManufacturer;
                }

                throw new Exception("Manufacturer with this name is already registered");
            }
        }

        public IEnumerable<PartManufacturer> GetAll()
        {
            var result = new List<PartManufacturer>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from part_manufacturer";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PartManufacturer partManufacturer = new PartManufacturer()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        Active = (bool) reader["active"]
                    };
                    result.Add(partManufacturer);
                }
            }
            return result.AsEnumerable();
        }

        public int Delete(long id)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from part_manufacturer where id = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}