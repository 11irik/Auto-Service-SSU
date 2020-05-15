using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class ContractDao : IContractDao
    {
        private SqlConnection _connection;

        public ContractDao()
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());
        }

        public Contract Create(long carId, DateTime startDate)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "if not exists (select * from contract where car_id = 0 and datediff(day, start_date, @startDate) > 0) begin insert into contract (car_id, start_date) values (@carID, @startDate) end";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@carID", carId);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = "select * from contract where car_id = @carID and datediff(day, start_date, @startDate) = 0";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@carID", carId);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Contract contract = new Contract()
                    {
                        ContractId = (long) reader["id"],
                        CarId = (long) reader["car_id"],
                        StartDate = (DateTime) reader["start_date"]
                    };
                    return contract;
                }

                throw new Exception("Not found");
            }
        }

        public IEnumerable<Contract> GetAllByPhone(string phoneNumber)
        {
            var result = new List<Contract>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from contract inner join car c on contract.car_id = c.id inner join client c2 on c.client_id = c2.id where c2.phone_number = @phoneNumber and end_date is null";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = DateTime.MinValue;
                    try
                    {
                        date = (DateTime) reader["end_date"];
                    }
                    catch (Exception e)
                    {
                        
                    }
                    Contract contract = new Contract()
                    {
                        ContractId = (long) reader["id"],
                        CarId = (long) reader["car_id"],
                        StartDate = (DateTime) reader["start_date"],
                        EndDate = date
                    };
                    result.Add(contract);
                }
            }

            return result.AsEnumerable();
        }

        public IEnumerable<Contract> GetAll()
        {
            var result = new List<Contract>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from contract";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = DateTime.MinValue;
                    try
                    {
                        date = (DateTime) reader["end_date"];
                    }
                    catch (Exception e)
                    {
                    }

                    Contract contract = new Contract()
                    {
                        ContractId = (long) reader["id"],
                        CarId = (long) reader["car_id"],
                        StartDate = (DateTime) reader["start_date"],
                        EndDate = date
                    };
                    result.Add(contract);
                }
            }

            return result.AsEnumerable();
        }

        public IEnumerable<Contract> GetAllOpened()
        {
            var result = new List<Contract>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from contract where end_date is null";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = DateTime.MinValue;
                    try
                    {
                        date = (DateTime) reader["end_date"];
                    }
                    catch (Exception e)
                    {
                    }

                    Contract contract = new Contract()
                    {
                        ContractId = (long) reader["id"],
                        CarId = (long) reader["car_id"],
                        StartDate = (DateTime) reader["start_date"],
                        EndDate = date
                    };
                    result.Add(contract);
                }
            }

            return result.AsEnumerable();
        }

        public IEnumerable<Contract> GetById(long id)
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());

            var result = new List<Contract>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from contract where id = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = DateTime.MinValue;
                    try
                    {
                        date = (DateTime) reader["end_date"];
                    }
                    catch (Exception e)
                    {
                    }

                    Contract contract = new Contract()
                    {
                        ContractId = (long) reader["id"],
                        CarId = (long) reader["car_id"],
                        StartDate = (DateTime) reader["start_date"],
                        EndDate = date
                    };
                    result.Add(contract);
                }
            }

            return result.AsEnumerable();
        }

        public Contract Update(long contractId, DateTime startDate, DateTime endDate)
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "update contract set start_date = @startDate, end_date = @endDate where id = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", contractId);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
               
                sql = "select * from contract where id = @id";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", contractId);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    DateTime date = DateTime.MinValue;
                    try
                    {
                        date = (DateTime) reader["end_date"];
                    }
                    catch (Exception e)
                    {
                    }
                    Contract contract = new Contract()
                    {
                        ContractId = (long) reader["id"],
                        CarId = (long) reader["car_id"],
                        StartDate = (DateTime) reader["start_date"],
                        EndDate = date
                    };
                    return (contract);
                }
            }

            throw new Exception("There is no contract with this id");
        }

        public int Delete(long contractId)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from contract where id = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", contractId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}