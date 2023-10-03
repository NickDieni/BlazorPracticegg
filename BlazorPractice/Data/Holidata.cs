using System;
using System.Net.Http;
using System.Text.Json;
using BlazorPractice.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


namespace BlazorPractice.Data
{
    public class Holidata
    {

        public async Task<PublicHoliday[]> HoliAsync()
        {
            var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://date.nager.at/api/v3/publicholidays/2022/DK");
            if (response.IsSuccessStatusCode)
            {
                using var jsonStream = await response.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<PublicHoliday[]>(jsonStream, jsonSerializerOptions);
            }
            return new PublicHoliday[0];
        }


        public List<User> GetBirthdays()
        {
            BuildConnectionString nyCon = new BuildConnectionString();
            string cstring = nyCon.ConnectionString;


            List<User> ListUser = new List<User>();

            using (SqlConnection con = new SqlConnection(cstring))
            {
                con.Open();

                string sqlQuery2 = "SELECT * FROM Birthday";

                using (SqlCommand command = new SqlCommand(sqlQuery2, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User Userdd = new User
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name1 = reader["Name1"].ToString(),
                                Datecollum = (DateTime)reader["Datecollum"]
                            };
                            ListUser.Add(Userdd);
                        }
                    }
                }
                con.Close();
            }
            return ListUser;
        }
    }

    public class PublicHoliday
    {
        public DateTime? Date { get; set; }
        public string? LocalName { get; set; }
    }

    public class User
    {
        public int ID { get; set; } 
        public string?  Name1 { get; set; }
        public DateTime Datecollum { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<User> Birthday { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
    
}

