using Entities.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        IConfiguration _configuration;

        public RatingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task AddRating(Rating rating)
        {
            string connectionString = _configuration.GetConnectionString("Store");
            string query = "INSERT INTO RATING(HOST, METHOD, PATH, REFERER, USER_AGENT, Record_Date) " +
                            "VALUES(@Host, @Method, @Path, @Referer, @UserAgent, @RecordDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Host", SqlDbType.VarChar, 50).Value = rating.Host;
                command.Parameters.Add("@Method", SqlDbType.VarChar, 10).Value = rating.Method;
                command.Parameters.Add("@Path", SqlDbType.VarChar, 50).Value = rating.Path;
                command.Parameters.Add("@Referer", SqlDbType.VarChar, 100).Value = rating.Referer;
                command.Parameters.Add("@UserAgent", SqlDbType.VarChar, 3000).Value = rating.UserAgent;
                command.Parameters.Add("@RecordDate", SqlDbType.DateTime).Value = rating.RecordDate;
                connection.Open();
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            return;
        }
    }
}
