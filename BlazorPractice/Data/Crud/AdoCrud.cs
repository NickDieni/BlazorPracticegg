using System;
using BlazorPractice.Data.Models;
using Microsoft.Data.SqlClient;

namespace BlazorPractice.Data.Crud
{
	public class AdoCrud : ICrud
	{
        private string? cString => _configuration.GetConnectionString("DefaultConnection");
        private readonly IConfiguration _configuration;

        public AdoCrud(IConfiguration configuration)
		{
            _configuration = configuration;
        }

        public void Create(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(cString))
            {
                string sqlQuery = "INSERT INTO Birthday (Name1, Datecollum) VALUES (@Name1, @Datecollum)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name1", user.Name1);
                    command.Parameters.AddWithValue("@Datecollum", user.Datecollum);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(cString))
            {
                string sqlQuery = $"UPDATE Birthday SET Name1 = @Name1, Datecollum = @Datecollum WHERE ID = {user.ID}";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name1", user.Name1);
                    command.Parameters.AddWithValue("@Datecollum", user.Datecollum);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}

