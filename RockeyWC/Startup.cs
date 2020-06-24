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
using RockeyWC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:RockeyWCProducts:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options => 
                options.UseSqlServer(Configuration["Data:RockeyWCIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<IActionLogRepository, FakeActionLogRepository>();

            services.AddMvc();
                //.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMemoryCache();
            services.AddSession();
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
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" }
                );

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );
                routes.MapRoute(
                    name: "Orders",
                    template: "{controller=Order}/{action=List}/{id?}");
                routes.MapRoute(
                    name: "Rentals",
                    template: "{controller=Rental}/{action=List}/{id?}");
                routes.MapRoute(
                    name: "Admin-Index",
                    template: "{controller=Admin}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "Admin-Edit",
                    template: "{controller=Admin}/{action=Edit}/{id?}");
                routes.MapRoute(
                    name: "ActionLogs",
                    template: "{controller=Home}/{action=ActionLogs}"
                );
                routes.MapRoute(
                    name: null,
                    template: "Account/{action}/{ReturnUrl}",
                    defaults: new { controller = "Accoubt" }
                );
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
