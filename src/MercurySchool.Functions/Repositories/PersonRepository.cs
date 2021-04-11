using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MercurySchool.Functions.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MercurySchool.Functions.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _sqlConnectionString;

        public PersonRepository(IConfiguration configuration) => _sqlConnectionString = DataUtilities.GetSqlConnectionString(configuration);

        public async Task<List<Person>> GetPersons(SqlPagination sqlPagination)
        {
            var persons = new List<Person>();

            using var sqlConnection = new SqlConnection(_sqlConnectionString);
            await sqlConnection.OpenAsync();

            using var sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "func.GetPersons";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            
            sqlCommand.Parameters.AddWithValue("@Offset", sqlPagination.Offset);
            sqlCommand.Parameters.AddWithValue("@Fetch", sqlPagination.Fetch);

            using var reader = await sqlCommand.ExecuteReaderAsync();

            if(!reader.HasRows){
                return persons;
            }
            
            while(await reader.ReadAsync()){
                var person = new Person{
                    
                    Id = (int)reader["id"],
                    FirstName = reader["FirstName"] as string,
                    MiddleName = reader["MiddleName"] as string,
                    LastName = reader["LastName"] as string
                };

                persons.Add(person);
            }

            return persons;
        }
    }
}