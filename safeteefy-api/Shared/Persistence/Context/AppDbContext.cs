using Microsoft.EntityFrameworkCore;
using safeteefy_api.Guardians.Domain.Models;
using safeteefy_api.Urgencies.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace safeteefy_api.Shared.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Urgency> Urgencies { get; set; }

        protected readonly IConfiguration _configuration;
        
        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Constrains -> Guardian
            builder.Entity<Guardian>().ToTable("Guardians");
            builder.Entity<Guardian>().HasKey(p => p.Id);
            builder.Entity<Guardian>().Property(p=> p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Guardian>().Property(p=> p.Username).IsRequired().HasMaxLength(30);
            builder.Entity<Guardian>().Property(p=> p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Guardian>().Property(p=> p.FirstName).HasMaxLength(60);
            builder.Entity<Guardian>().Property(p=> p.LastName).HasMaxLength(60);
            builder.Entity<Guardian>().Property(p=> p.Gender).IsRequired();
            builder.Entity<Guardian>().Property(p=> p.Address);
            
            //Relations
            builder.Entity<Guardian>()
                .HasMany(p => p.Urgencies)
                .WithOne(p => p.Guardian)
                .HasForeignKey(p => p.GuardianId);
            
            //Constrains -> Urgency
            builder.Entity<Urgency>().ToTable("Urgencies");
            builder.Entity<Urgency>().HasKey(p => p.Id);
            builder.Entity<Urgency>().Property(p=> p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Urgency>().Property(p=> p.Title).IsRequired();
            builder.Entity<Urgency>().Property(p=> p.Summary);
            builder.Entity<Urgency>().Property(p=> p.Latitude).IsRequired();
            builder.Entity<Urgency>().Property(p=> p.Longitude).IsRequired();
            builder.Entity<Urgency>().Property(p=> p.ReportedAt);
            builder.Entity<Urgency>().Property(p=> p.GuardianId).IsRequired();
        }
    }
}