using Microsoft.Extensions.Configuration;
using Npgsql;

namespace School.Data
{
    public class DatabaseContext
    {
        private readonly IConfiguration _configuration;
        
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async void  TestConnection()
        {
            var connectionString  = _configuration.GetConnectionString("DefaultConnection");
            await using var connection = new NpgsqlConnection(connectionString);
            {
                try
                {
                    await connection.OpenAsync();
                    Console.WriteLine("Database connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database connection failed! {ex.Message}");
                }
            }
        }
    }
}