// Import necessary libraries
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

// Define the BowlerContext class
namespace Mission10.Data
{
    // Partial class extending DbContext to manage database operations
    public partial class BowlerContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // Default constructor
        public BowlerContext()
        {
        }

        // Constructor with options
        public BowlerContext(DbContextOptions<BowlerContext> options)
            : base(options)
        {
        }

        // Define a DbSet for the Bowlers table
        public virtual System.Data.Entity.DbSet<Bowler> Bowlers { get; set; }
        
        // Define a DbSet for the Teams table
        public virtual System.Data.Entity.DbSet<Team> Teams { get; set; }

        // Method to configure the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=BowlingLeague.sqlite");

        // Method to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Bowler entity
            modelBuilder.Entity<Bowler>(entity =>
            {
                // Set indexes for BowlerLastName and TeamId
                entity.HasIndex(e => e.BowlerLastName, "BowlerLastName");
                entity.HasIndex(e => e.TeamId, "BowlersTeamID");

                // Define column types and names
                entity.Property(e => e.BowlerId).HasColumnType("INT").HasColumnName("BowlerID");
                entity.Property(e => e.BowlerAddress).HasColumnType("nvarchar (50)");
                entity.Property(e => e.BowlerCity).HasColumnType("nvarchar (50)");
                entity.Property(e => e.BowlerFirstName).HasColumnType("nvarchar (50)");
                entity.Property(e => e.BowlerLastName).HasColumnType("nvarchar (50)");
                entity.Property(e => e.BowlerMiddleInit).HasColumnType("nvarchar (1)");
                entity.Property(e => e.BowlerPhoneNumber).HasColumnType("nvarchar (14)");
                entity.Property(e => e.BowlerState).HasColumnType("nvarchar (2)");
                entity.Property(e => e.BowlerZip).HasColumnType("nvarchar (10)");
                entity.Property(e => e.TeamId).HasColumnType("INT").HasColumnName("TeamID");

                // Define the relationship with the Team entity
                entity.HasOne(d => d.Team).WithMany(p => p.Bowlers).HasForeignKey(d => d.TeamId);
            });

            // Configure the Team entity
            modelBuilder.Entity<Team>(entity =>
            {
                // Set an index for TeamId and make it unique
                entity.HasIndex(e => e.TeamId, "TeamID").IsUnique();

                // Define column types and names
                entity.Property(e => e.TeamId).HasColumnType("INT").HasColumnName("TeamID");
                entity.Property(e => e.CaptainId).HasColumnType("INT").HasColumnName("CaptainID");
                entity.Property(e => e.TeamName).HasColumnType("nvarchar (50)");
            });

            // Call the partial method for further model configuration
            OnModelCreatingPartial(modelBuilder);
        }

        // Partial method to further configure the model (if needed)
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
