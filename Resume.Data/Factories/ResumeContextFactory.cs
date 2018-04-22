using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Resume.Data.Contexts;
using System;
using System.IO;

namespace Resume.Data.Factories
{
    public class ResumeContextFactory : IDesignTimeDbContextFactory<ResumeContext>
    {
        public ResumeContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<ResumeContext>();

            var connectionString = configuration.GetConnectionString("ResumeConnection");

            builder.UseSqlServer(connectionString);

            return new ResumeContext(builder.Options);
        }
    }
}
