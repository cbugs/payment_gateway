using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentGatewayData.Context;
using PaymentGatewayData.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGatewayData.Repository.Interface;
using PaymentGatewayData.Repository;

namespace MerchantAdmin
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // DB Context Services
            services.AddDbContext<MerchantContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:MerchantDB"]));

            // Data Repository Services
            services.AddScoped<IMerchantRepository, MerchantRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Merchant}/{action=Index}/{id?}");
            });
        }
    }
}
