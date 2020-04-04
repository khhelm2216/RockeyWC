using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockeyWC.Database;
using RockeyWC.FilterLibrary;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RockeyWC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Database access
            services.AddTransient<IActionLogRepository, FakeActionLogRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name:"Products",
                    template: "{controller=Product}/{action=List}/{id?}");
                routes.MapRoute(
                    name: "Orders",
                    template: "{controller=Order}/{action=List}/{id?}");
                routes.MapRoute(
                    name: "Rentals",
                    template: "{controller=Rental}/{action=List}/{id?}");
                routes.MapRoute(
                    name: "Admin",
                    template: "{controller=Admin}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "Admin",
                    template: "{controller=Admin}/{action=Edit}/{id?}");
                routes.MapRoute(
                    name: "ActionLogs",
                    template: "{controller=Home}/{action=ActionLogs}"
                );
            });
        }
    }
}
