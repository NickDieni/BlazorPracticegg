using System;
using System.Net.Http;
using System.Text.Json;
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
        public DateTime Date { get; set; }
        public string LocalName { get; set; }
    }
}

