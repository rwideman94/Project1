using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project1.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Project1.Models.Repositories;

namespace Project1.UI
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
            services.AddDbContext<Project1DbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("Project1DbContext")));
            services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("TestDbContext")));
            services.AddControllersWithViews();
            //services.AddIdentity<AppUser, IdentityRole>()
            //    //.AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<Project1DbContext>();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<TestDbContext>();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/User/Login");

            services.AddTransient<IAccountRepo, AccountRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<ILoanRepo, LoanRepo>();
            services.AddTransient<ITermDepositRepo, TermDepositRepo>();

            services.AddControllers(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

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

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
