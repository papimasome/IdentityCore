using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplatePrj.Data;
using TemplatePrj.Models;

namespace TemplatePrj
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
           
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
              
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await ContextSeed.SeedRolesAsync(userManager, roleManager);
                    await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {

                    logger.Error(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                    //webBuilder.ConfigureLogging(x =>
                    //{
                    //    x.ClearProviders();
                    //    x.AddConsole();
                    //    x.AddDebug();
                    //    x.AddEventLog();
                      
                    //});
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Trace);

                })
                .UseNLog();  // NLog: Setup NLog for Dependency injection;
    }
}
