using CookiAuthCrud.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        public PersonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration["ConnectionStrings:DBSettingConnection"]);
        }
        public async Task<CreatePersonResponse> CreatePerson(CreatePersonRequest request)
        {
            CreatePersonResponse response = new CreatePersonResponse();
            response.IsSuccess = true;
            response.Message = "Success";
            
            try
            {
                string query = "Insert into Person (FirstName, LastName, Age) values(@FirstName, @LastName, @Age)";
                await OpenConnectionAsync();
                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@FirstName", request.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", request.LastName);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status<=0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Error";
                    }
                }
            }
            catch(SqlException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _connection.Close();
            }
            return response;
        }
        public async Task<GetPersonsResponse> GetPersons()
        {
            GetPersonsResponse response = new GetPersonsResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            string query = "Select UserId, FirstName, LastName, Age, Phone from dbo.Person";
            try
            {
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 180;
                    //_connection.Open();
                    await OpenConnectionAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            response.Persons = new List<Person>();
                            while (await reader.ReadAsync())
                            {
                                Person person = new Person();
                                person.UserId = reader["UserId"] != DBNull.Value ? Convert.ToInt32(reader["UserId"].ToString()) : 0;
                                person.FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : string.Empty;
                                person.LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : string.Empty;
                                person.Age = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"].ToString()) : 0;
                                person.Phone = reader["Phone"] != DBNull.Value ? Convert.ToInt32(reader["Phone"].ToString()) : 0;
                                response.Persons.Add(person);
                            }
                        }
                    }
                }                
            }
            catch (SqlException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;                
            }
            finally
            {
                _connection.Close();
            }
            return response;
        }

        public async Task<UpdatePersonResponse> UpdatePerson(UpdatePersonRequest request)
        {
            UpdatePersonResponse response = new UpdatePersonResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            string query = "Update Person set FirstName = @FirstName, LastName = @LastName, Age = @Age Where UserId = @UserId";
            try
            {
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue("@UserId", request.UserId);
                    command.Parameters.AddWithValue("@FirstName", request.FirstName);
                    command.Parameters.AddWithValue("@LastName", request.LastName);
                    command.Parameters.AddWithValue("@Age", request.Age);
                    await OpenConnectionAsync();
                    int status = await command.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Error while updation";
                    }
                }
            }
            catch (SqlException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally { _connection.Close();  }
            return response;
        }
        public async Task<DeletePersonResponse> DeletePerson(DeletePesronRequest request)
        {
            DeletePersonResponse response = new DeletePersonResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            string query = "Delete From Person Where UserId = @UserId";
            try
            {
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue("@UserId", request.UserId);
                    await OpenConnectionAsync();
                    int status = await command.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Error while deletion";
                    }
                }
            }
            catch (SqlException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally { _connection.Close(); }
            return response;
        }
        private async Task OpenConnectionAsync()
        {
            if (_connection.State != ConnectionState.Open)
                await _connection.OpenAsync();
        }
    }
}
