using AdmissionForm.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AdmissionForm.AdmissionApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<State> States { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the foreign key relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.State)
                .WithMany()
                .HasForeignKey(s => s.StateId)
                .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior based on your requirements
        }
    }
}
