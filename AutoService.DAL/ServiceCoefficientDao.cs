using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class ServiceCoefficientDao : IServiceCoefficientDao
    {
        private SqlConnection _connection;

        public ServiceCoefficientDao()
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());
        }
        
        public ServiceCoefficient Create(string name, double coefficient)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "insert into coefficient (name, coefficient) values (@name, @coefficient)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@coefficient", coefficient);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = "select * from coefficient where name = @name";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                var reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    ServiceCoefficient serviceCoefficient = new ServiceCoefficient()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        Coefficient = (double) reader["coefficient"]
                    };
                    return serviceCoefficient;
                }

                throw new Exception("Coefficient with this name is already registered");
            }
        }

        public IEnumerable<ServiceCoefficient> GetAll()
        {
            var result = new List<ServiceCoefficient>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from coefficient";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ServiceCoefficient serviceCoefficient = new ServiceCoefficient()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        Coefficient = (double) reader["coefficient"]
                    };
                    result.Add(serviceCoefficient);
                }
            }
            return result.AsEnumerable();
        }

        public int Delete(long id)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from coefficient where id = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}