using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class ContractDao : IContractDao
    {
        private SqlConnection _connection = DbConnection.GetSqlConnection();
        
        public Contract Create(long carId, DateTime startDate)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "insert into contract (car_id, start_date) values (@carID, @startDate)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@carID", carId);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                
                sql = "select * from contract where car_id = @carID and start_date = @startDate";
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
                    Contract contract = new Contract()
                    {
                        ContractId = (long) reader["id"],
                        CarId = (long) reader["car_id"],
                        StartDate = (DateTime) reader["start_date"],
                        EndDate = (DateTime) reader["end_date"]
                    };
                    result.Add(contract);
                }
            }
            return result.AsEnumerable();
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