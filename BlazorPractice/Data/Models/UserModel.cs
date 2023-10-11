using System;
namespace BlazorPractice.Data.Models
{
	public class UserModel
	{
        public int ID { get; set; }
        public string? Name1 { get; set; }
        public DateTime Datecollum { get; set; } = DateTime.Now;
    }
}

