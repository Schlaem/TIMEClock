using Microsoft.EntityFrameworkCore;
using System.IO;
using TIMEClock.UI.WPF.Entities;

namespace TIMEClock.UI.WPF.EFCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<TimeRecord> TimeRecords { get; set; }

        public AppDbContext() : base()
        {
            if(Database.EnsureCreated())
            {

            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Properties.Settings.Default.DbConnectionString;

            if(string.IsNullOrWhiteSpace(connectionString))
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Schlæmware", "TIMEClock", "TIMEClock.sqlite");
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                connectionString = $"Data Source={filePath}";

                Properties.Settings.Default.DbConnectionString = connectionString;
                Properties.Settings.Default.Save();
            }

            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeRecord>().HasData(
                new TimeRecord { ID = 1, Created = DateTime.Now, From = new DateTime(2026, 1, 5, 7, 5, 0), Until = new DateTime(2026, 1, 5, 11, 35, 0) },
                new TimeRecord { ID = 2, Created = DateTime.Now, From = new DateTime(2026, 1, 5, 12, 0, 0) });
        }
    }
}
