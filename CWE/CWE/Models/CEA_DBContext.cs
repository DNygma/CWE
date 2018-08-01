using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using CWE.Services;

namespace CWE.Models
{
    public class CEA_DBContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Scheduler> Scheduler { get; set; }
        public virtual DbSet<Notifier> Notifier { get; set; }
        public virtual DbSet<CurrencyQueue> CurrencyQueue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-O7AC2QN;Database=CurrencyExchangeDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }

        }

        public CEA_DBContext(DbContextOptions<CEA_DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

}
