using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.Data.SqlClient;

namespace AutoService.DAL
{
    public class ClientDao : IClientDao
    {
        private SqlConnection _connection;

        public ClientDao()
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());
        }


        public Client Create(string name, string lastName, string phoneNumber)
        {
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "insert into client (name, last_name, phone_number) values (@name, @lastName, @phoneNumber)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                sql = "select * from client where phone_number = @phoneNumber";
                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                var reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    Client client = new Client()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        LastName = (string) reader["last_name"],
                        PhoneNumber = (string) reader["phone_number"],
                    };
                    return client;
                }
                
                throw new Exception("Phone number is already registered");
            }

            //todo check exception
        }

        public Client Get(string phoneNumber)
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());

            using (_connection)
            {
                _connection.Open();

                string sql = "select * from client where phone_number = @phoneNumber";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Client client = new Client()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        LastName = (string) reader["last_name"],
                        PhoneNumber = (string) reader["phone_number"]
                    };
                    return client;
                }

                throw new Exception("Not found");
            }
        }

        public Client Get(long id)
        {
            _connection = new SqlConnection(DalConfiguration.GetSqlConnectionString());

            using (_connection)
            {
                _connection.Open();

                string sql = "select * from client where id  = @id";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Client client = new Client()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        LastName = (string) reader["last_name"],
                        PhoneNumber = (string) reader["phone_number"]
                    };
                    return client;
                }

                throw new Exception("Not found");
            }
        }

        public IEnumerable<Client> GetAll()
        {
            var result = new List<Client>();
            using (_connection)
            {
                _connection.Open();

                string sql =
                    "select * from client";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Client client = new Client()
                    {
                        Id = (long) reader["id"],
                        Name = (string) reader["name"],
                        LastName = (string) reader["last_name"],
                        PhoneNumber = (string) reader["phone_number"]
                    };
                    result.Add(client);
                }
            }

            return result.AsEnumerable();
        }

        public int Delete(string phoneNumber)
        {
            using (_connection)
            {
                _connection.Open();

                string sql = "delete from client where phone_number = @phoneNumber";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}