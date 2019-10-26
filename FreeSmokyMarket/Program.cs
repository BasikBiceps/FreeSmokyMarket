using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using FreeSmokyMarket.Data;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.EF.Repositories;

namespace FreeSmokyMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<FreeSmokyMarketContext>();
                    SampleData.Initialize(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
