using Entities.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int rowAffected = 0;
            string query = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@HOST", SqlDbType.VarChar, 50).Value = rating.Host;
                command.Parameters.Add("@METHOD", SqlDbType.VarChar, 10).Value = rating.Method;
                command.Parameters.Add("@PATH", SqlDbType.VarChar, 50).Value = rating.Path;
                command.Parameters.Add("@REFERER", SqlDbType.VarChar, 100).Value = rating.Referer;
                command.Parameters.Add("@USER_AGENT", SqlDbType.VarChar, 3000).Value = rating.UserAgent;
                command.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = rating.RecordDate;
                connection.Open();
                rowAffected += command.ExecuteNonQuery();
                connection.Close();
            }
            return;
        }
    }
}
