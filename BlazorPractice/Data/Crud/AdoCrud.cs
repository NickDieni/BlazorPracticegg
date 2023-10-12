using System;
using BlazorPractice.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
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
        public void Delete(int user)
        {
            using (SqlConnection connection = new SqlConnection(cString))
            {
                connection.Open();

                string sqlQuery = $"DELETE FROM Birthday WHERE ID = {user}";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public List<UserModel> Read(UserModel user)
        {
            List<UserModel> userList = new List<UserModel>();

            using (SqlConnection con = new SqlConnection(cString))
            {
                con.Open();

                string sqlQuery2 = "SELECT * FROM Birthday";

                using (SqlCommand command = new SqlCommand(sqlQuery2, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserModel userModel = new UserModel
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name1 = reader["Name1"].ToString(),
                                Datecollum = (DateTime)reader["Datecollum"]
                            };
                            userList.Add(userModel);
                        }
                    }
                }
                con.Close();
            }
            return userList;
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

