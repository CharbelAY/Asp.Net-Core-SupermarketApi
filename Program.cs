using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Supermarket.API.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.API.Domain.Models;


namespace Supermarket.API
{
    public class Program
    {

        private static void AddTestData(AppDbContext context)
        {
            var Category1 = new Category
            {
                Id = 100,
                Name = "Fruits & Vegetables"
            };
        
            context.Categories.Add(Category1);
        
            var Category2 = new Category
            {
                Id = 101,
                Name = "Drinks",
            };
        
            context.Categories.Add(Category2);
        
            context.SaveChanges();
        }
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            using(var context = scope.ServiceProvider.GetService<AppDbContext>())
            // {
            //     context.Database.EnsureCreated();
            // }

            AddTestData(context);

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
