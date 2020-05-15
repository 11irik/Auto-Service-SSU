using System;
using System.Collections.Generic;
using System.Data;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class ContractServicesDao : IContractServicesDao
    {
        private SqlConnection _connection;

        public ContractServicesDao()
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());
        }
        
        public ContractService Create(long contractId, long serviceId, long coefId, DateTime date)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "insert into contract_services (contract_id, service_id, coefficient_id, date_of_service) values (@contractId, @serviceId, @coefId, @date)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@contractId", contractId);
                cmd.Parameters.AddWithValue("@serviceId", serviceId);
                cmd.Parameters.AddWithValue("@coefId", coefId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = "select * from contract_services where contract_id = @contractId and service_id = @serviceId";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@contractId", contractId);
                cmd.Parameters.AddWithValue("@serviceId", serviceId);
                var reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    ContractService service = new ContractService()
                    {
                        ContractId = (long) reader["contract_id"],
                        ServiceId = (long) reader["service_id"],
                        CoefId = (long) reader["coefficient_id"],
                        Date = (DateTime) reader["date_of_service"]
                    };
                    return service;
                }

                throw new Exception("Error");//todo
            }
        }

        public IEnumerable<ContractService> GetAllByContract(long contractId)
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());

            var result = new List<ContractService>();

            using (_connection)
            {
                _connection.Open();

                string sql = "select service_id, price, coefficient_id, coefficient, s.name as name, date_of_service from contract_services inner join coefficient c on contract_services.coefficient_id = c.id inner join service s on contract_services.service_id = s.id where contract_id = @contractId";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@contractId", contractId);
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    DateTime d = DateTime.MinValue;
                    try
                    {
                        d = (DateTime) reader["date_of_service"];
                    }
                    catch (Exception e)
                    {
                    }

                    ContractService service = new ContractService()
                    {
                        ServiceId = (long) reader["service_id"],
                        Price = (double) reader["price"],
                        CoefId = (long) reader["coefficient_id"],
                        Date = d,
                        Name = (string) reader["name"],
                        Coef = (double) reader["coefficient"]
                    };
                    result.Add(service);
                }

                return result;
            }
        }

        public int Delete(long contractId, long serviceId)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from contract_services where contract_id = @contractId and service_id = @serviceId";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@contractId", contractId);
                cmd.Parameters.AddWithValue("@serviceId", serviceId);
                return cmd.ExecuteNonQuery();
            }
        }

        public double GetContractPrice(long id)
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());

            double sum = 0;
            using (_connection)
            {
                _connection.Open();

                
                SqlCommand cmd = new SqlCommand("ServicesSum", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@ContractId", id);
                cmd.Parameters.AddWithValue("@Sum", sum);
                cmd.ExecuteNonQuery();
            }

            return sum;
        }
    }
}