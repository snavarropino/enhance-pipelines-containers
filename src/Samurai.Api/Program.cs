using System;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Samurai.Api.Infrastructure;

namespace Samurai.Api
{
    public static class Program
    {
        public static bool ErrorDbContext = false;
        public static bool ErrorSeed = false;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    Thread.Sleep(10000);
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<SamuraiContext>();
                    DbInitializer.Initialize(context);

                }
            }
            catch (Exception e)
            {
                Program.ErrorSeed = true;
                Program.Error += e.Message;
            }
            
        }

        public static string Error { get; set; }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
