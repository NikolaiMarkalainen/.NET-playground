namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = File.OpenRead(".env"))
            {
                DotNetEnv.Env.Load();
            }

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => $"Hello World!, {Environment.GetEnvironmentVariable("POSTGRES_USER")}!");

            app.Run();
        }
    }
}

