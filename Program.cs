using School.Data;

namespace School
{
    public class Program
    {
        public static void Main(string[] args)
        {
        DotNetEnv.Env.Load(".env");
        var builder = WebApplication.CreateBuilder(args);

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables() 
            .Build();

        var connectionTester = new DatabaseContext(configuration);
        connectionTester.TestConnection();
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        }
    }

}

