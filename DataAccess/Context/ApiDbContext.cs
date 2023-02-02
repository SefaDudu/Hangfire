using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ApiDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseNpgsql("host=localhost; port=5432; database=hangfire; username=postgres; password=postgrespw");

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DataAccess.Model.File> Files { get; set; }

    }
}
