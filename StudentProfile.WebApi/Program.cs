using StudentProfile.Persistence;
using StudentProfile.Persistence.Context;
using System;

namespace StudentProfile.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvaider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvaider.GetRequiredService<StudentProfileContext>();
                    DbInitializer.Initializer(context);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message, "An error occurred while app initialization");           
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}