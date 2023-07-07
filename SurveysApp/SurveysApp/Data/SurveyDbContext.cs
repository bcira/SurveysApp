using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SurveysApp.Models;

namespace SurveysApp.Data
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options) { }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }

        public DbSet<Response> Responses { get; set; }
    }



    public class SurveyDbContextFactory : IDesignTimeDbContextFactory<SurveyDbContext>
    {
        public SurveyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SurveyDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-JQT7BLC\\SQLEXPRESS;Database=Survey;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new SurveyDbContext(optionsBuilder.Options);
        }
    }
}

