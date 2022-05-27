using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Retail.Customer.Rewards.Data;
using Retail.Customer.Rewards.Services.Service;
using Retail.Customer.Rewards.Services.Interface;


namespace Retail.Customer.Rewards.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var nameSpace = typeof(Startup).Namespace;
            services.AddDbContext<DataContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase"), x => x.MigrationsAssembly(nameSpace));
                });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRewardsService, RewardsService>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MigrateAndSeed();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    public static class MigrateAndSeedDb
    {
        public static void MigrateAndSeed(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            using var ctx = serviceScope.ServiceProvider.GetService<DataContext>();

            if (ctx != null)
            {
                ctx.AddOrUpdateSeedData();
                ctx.SaveChanges();
            }
        }
    }
}
