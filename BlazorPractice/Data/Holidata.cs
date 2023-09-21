using System;
using System.Net.Http;
using System.Text.Json;
using BlazorPractice.Data;
using Microsoft.EntityFrameworkCore;

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

