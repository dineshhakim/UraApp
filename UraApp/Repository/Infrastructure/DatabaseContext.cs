


using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UraApp.Models;
using System.IO;

namespace UraApp.Repository.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public IConfigurationRoot Configuration { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            Configuration = configuration.Build();
            options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }

}
