using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.BLL_Services;
using BLL.Collections;
using BLL.Logic_interfaces;
using BLL.Logic_interfaces.Collection_Interfaces;
using BLL.Models;
using DAL.DatabaseConnectionHandler;
using Logic_interfaces;
using Logic_interfaces.Services_Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fontys_S2_Project___Car_to_go
{
    public class Startup
    {
        private string ConnectionString="";
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            ConnectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ClaimsIssuer = "/User/AccessDenied";
                options.LoginPath = "/User/UserLogin";
                options.LogoutPath = "/User/UserLogin";
                options.AccessDeniedPath = "/User/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true;

            });

            services.AddControllersWithViews();
            services.AddScoped<IUserCollection, UserCollection>();
            services.AddScoped<IUser, User>();
            services.AddScoped<IReservation, Reservation>();
            services.AddScoped<IReservationCollection, ReservationCollection>();
            services.AddScoped<IVehicle, Vehicle>();
            services.AddScoped<IVehicleCollection, VehicleCollection>();
            services.AddScoped<IReservationServices, ReservationServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            DBConnectionHandler.SetConnectionString(ConnectionString);
            
        }
    }
}
