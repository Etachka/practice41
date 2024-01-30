using Azure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using practice.Models;

using System;
using System.Linq;

namespace practice.Database
{
    public class PracticeContext : DbContext
    {
        private static PracticeContext _instance = new PracticeContext();
        public PracticeContext()
        {

        }
        public static PracticeContext Instance
        {
            get
            {
                return _instance;
            }
        }

        public DbSet<City> Cites { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<ActivityJury> ActivityJures { get; set; }
        public DbSet<Activity> Activites { get; set; }
        public DbSet<Ivent> Ivents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=hnt8.ru;Port=5432;Database=AKVTCommonPractice;UserID=admin;Password=admin");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.Id).UseIdentityAlwaysColumn()
                .ValueGeneratedOnAdd();

            var dateTimeProperties = modelBuilder.Model.GetEntityTypes()
                  .SelectMany(e => e.GetProperties())
                  .Where(p => p.ClrType == typeof(DateTime));

            modelBuilder.HasDefaultSchema("silov-barinov-maltsev");

            foreach (var property in dateTimeProperties)
            {
                modelBuilder.Entity(property.DeclaringEntityType.ClrType)
                    .Property(property.Name)
                    .HasConversion(new UtcDateTimeConverter());
            }

        }
    }
    public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
    {
        public UtcDateTimeConverter() : base(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        { }
    }
}
