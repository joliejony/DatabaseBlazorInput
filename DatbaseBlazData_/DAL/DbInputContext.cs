using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer; // Add this using directive
using DatbaseBlazData_.Models;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DatbaseBlazData_.DAL
{
    public class DbInputContext : DbContext
    {
        public DbInputContext(DbContextOptions<DbInputContext> options) : base(options)
        {
        }
        // Define your DbSets here. For example:
        //public DbSet<YourEntity> YourEntities { get; set; }

        // Default DbSet for imported Excel rows. Adjust the entity or remove if you use a different model.
        public DbSet<ExcelRow> ExcelRows { get; set; }
    
        private static DbContextOptions<DbInputContext> BuildOptionsFromSession(IHttpContextAccessor httpContextAccessor)
        {
            var connectionString = httpContextAccessor?.HttpContext?.Session.GetString("UserConnectionString");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("No database connection configured for this session.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<DbInputContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               
                // For development: accept the server certificate if it's not from a trusted CA
                optionsBuilder.UseSqlServer("Server=LPTDCS001\\SQLEXPRESS;Database=InputDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships and constraints here. For example:
            // modelBuilder.Entity<YourEntity>()
            //     .HasOne(e => e.RelatedEntity)
            //     .WithMany()
            //     .HasForeignKey(e => e.RelatedEntityId)
            //     .OnDelete(DeleteBehavior.Restrict);
        }




    }




}

//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using WorkAloneCheck.Models;
//using Microsoft.AspNetCore.Http;

//namespace WorkAloneCheck.DAL
//{
//    public class WorkerContext : DbContext
//    {
//        // Keep only the standard EF Core constructor that accepts DbContextOptions<T>.
//        public WorkerContext(DbContextOptions<WorkerContext> options)
//            : base(options)
//        {
//        }

//        private static DbContextOptions<WorkerContext> BuildOptionsFromSession(IHttpContextAccessor httpContextAccessor)
//        {
//            var connectionString = httpContextAccessor?.HttpContext?.Session.GetString("UserConnectionString");
//            if (string.IsNullOrWhiteSpace(connectionString))
//            {
//                throw new InvalidOperationException("No database connection configured for this session.");
//            }

//            var optionsBuilder = new DbContextOptionsBuilder<WorkerContext>();
//            optionsBuilder.UseSqlServer(connectionString);
//            return optionsBuilder.Options;
//        }

//        public DbSet<BoardOperator> BoardOperators { get; set; }
//        public DbSet<Company> Companies { get; set; }
//        public DbSet<Facility> Facilities { get; set; }
//        public DbSet<Worker> Workers { get; set; }
//        public DbSet<WorkerType> WorkerType { get; set; }
//        public DbSet<WorkingAloneAll> WorkingAloneAll { get; set; }
//        public DbSet<WorkLocation> WorkLocation { get; set; }
//        public DbSet<Alarm> Alarms { get; set; }
//        public DbSet<ArchivedWorkingAloneAll> ArchivedWorkingAloneAll { get; set; }
//        public DbSet<Managers> Managers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                // Example: Use SQL Server. Replace with your actual connection string.
//                optionsBuilder.UseSqlServer("Server=LPTDCS002\\SQLEXPRESS;Database=WorkAloneCheckDb;Trusted_Connection=True;MultipleActiveResultSets=true");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Worker
//            modelBuilder.Entity<WorkingAloneAll>()
//                .HasOne(w => w.Worker)
//                .WithMany()
//                .HasForeignKey(w => w.WorkerID)
//                .OnDelete(DeleteBehavior.Restrict);

//            // BoardOperator
//            modelBuilder.Entity<WorkingAloneAll>()
//                .HasOne(w => w.BoardOperator)
//                .WithMany()
//                .HasForeignKey(w => w.BoardOperatorId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Company
//            modelBuilder.Entity<WorkingAloneAll>()
//                .HasOne(w => w.Company)
//                .WithMany()
//                .HasForeignKey(w => w.CompanyId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // WorkLocation
//            modelBuilder.Entity<WorkingAloneAll>()
//                .HasOne(w => w.WorkLocation)
//                .WithMany()
//                .HasForeignKey(w => w.WorkLocationId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // WorkerType
//            modelBuilder.Entity<WorkingAloneAll>()
//                .HasOne(w => w.WorkerType)
//                .WithMany()
//                .HasForeignKey(w => w.WorkerTypeId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Alarm
//            modelBuilder.Entity<Alarm>()
//                .HasOne(a => a.WorkingAloneAll)
//                .WithMany(w => w.Alarms)
//                .HasForeignKey(a => a.WorkingAloneAllId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Worker -> Manager (break multiple cascade path)
//            modelBuilder.Entity<Worker>()
//                .HasOne(w => w.Manager)
//                .WithMany()
//                .HasForeignKey(w => w.ManagerId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Worker -> Company (avoid cascades from Company directly to Workers)
//            modelBuilder.Entity<Worker>()
//                .HasOne(w => w.Company)
//                .WithMany(c => c.Workers)
//                .HasForeignKey(w => w.CompanyId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Worker -> WorkerType (align FK and avoid cascade)
//            modelBuilder.Entity<Worker>()
//                .HasOne(w => w.WorkerType)
//                .WithMany()
//                .HasForeignKey(w => w.WorkerTypeId)
//                .OnDelete(DeleteBehavior.Restrict);
//        }


//    }
//}