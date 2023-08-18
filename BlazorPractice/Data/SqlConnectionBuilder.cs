using System;

namespace BlazorPractice.Data
{
    public class BuildConnectionString
	{
        private string Server { get; set; } = "192.168.23.112,1433";
        private string Database { get; set; } = "Bibliotek";
        private string Username { get; set; } = "Nick";
        private string Password { get; set; } = "Passw0rd";

        public string ConnectionString => BuildConnectionStrin();

        private string BuildConnectionStrin()
        {
            var connectionString = $"Server={Server};Database={Database}";
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                connectionString += $";User Id={Username};Password={Password}";
            }
            return connectionString;
        }
    }

}



