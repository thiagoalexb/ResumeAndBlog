using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Resume.Data.Configurations.Config;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Resume.Data.Contexts
{
    public class ResumeContext : BaseDbContext
    {
        public ResumeContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToMapping = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass
                                                                && typeof(IConfiguring).IsAssignableFrom(x)).ToList();
            
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.ApplyConfiguration(mappingClass);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
