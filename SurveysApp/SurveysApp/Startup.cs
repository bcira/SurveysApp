using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SurveysApp.Data;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SurveysApp.Models;
using Microsoft.Data.SqlClient;

namespace SurveysApp
{
    public class Startup
    {



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

           // app.UseMiddleware<CustomMiddleware>();

            app.UseRouting();

           // app.UseAuthentication();

           // app.UseAuthorization(); 

           /* app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "TakeSurvey",
                    pattern: "survey/takesurvey/{id}",
                    defaults: new { controller = "Survey", action = "TakeSurvey" }
); 
            });  */


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "Survey",
                    template: "{controller=Survey}/{action=Create}/{id?}");

                routes.MapRoute(
                    name: "Login",
                    template: "{controller=Account}/{action=Login}/{id?}");


            });

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //Configuration = configuration;
            // Other service registrations

            // Add DbContext using the connection string from appsettings.json
            services.AddDbContext<SurveyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Server=DESKTOP-JQT7BLC\\SQLEXPRESS;Database=Survey;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True")));




            

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
        });  


            services.AddIdentity<SurveysApp.Models.AppUser, IdentityRole>()
                .AddEntityFrameworkStores<SurveyDbContext>()
                .AddDefaultTokenProviders();   
          

        }



    }
    }



