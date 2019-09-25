using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using LibraryManagement;
using Microsoft.Extensions.DependencyInjection;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var services = host.Services.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetRequiredService<DemoContext>();
                var u = dbContext.Users.Where(x => x.UserType == "admin").FirstOrDefault();
                if (u == null)
                {
                    User user = new User();
                    user.Name = "Admin";
                    user.Email = "Admin@gmail.com";
                    user.Address = "Dhaka";
                    user.UserType = "admin";
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }

            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
