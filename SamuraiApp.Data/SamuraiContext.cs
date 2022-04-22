using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {

        public SamuraiContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Pedang> Pedangs { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\sqlexpress;Initial Catalog=SamuraiTestDb");
            }

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\sqlexpress;Initial Catalog=SamuraiDb")
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name,
                DbLoggerCategory.Database.Transaction.Name},
                Microsoft.Extensions.Logging.LogLevel.Debug)
                .EnableSensitiveDataLogging()
                ;
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>().HasMany(s => s.Battles).WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>(bs => bs.HasOne<Battle>().WithMany(),
                bs => bs.HasOne<Samurai>().WithMany())
                .Property(bs => bs.DateJoined)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Horse>().ToTable("Horses");
            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");
        }
    }
}
