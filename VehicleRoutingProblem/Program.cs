using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using VehicleRoutingProblem.Data;
using Microsoft.Extensions.Logging;

namespace VehicleRoutingProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            ///the first time you run the application, the database will be created and seeded with test data. Whenever you change 
            ///your data model, you can delete the database, update your seed method, and start afresh with a new database the same
            ///way.In later tutorials, you'll see how to modify the database when the data model changes, without deleting and re-creating it.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<Data.vrpDBContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                { 
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex.Message, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }
    }
}
