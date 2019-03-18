using Microsoft.EntityFrameworkCore;
using System;
using timesheet.model;

namespace timesheet.data
{
    public class TimesheetDb : DbContext
    {
        public TimesheetDb(DbContextOptions<TimesheetDb> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<EmployeeTimeSheet> EmployeeTimeSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(t => t.Tasks);

            modelBuilder.Entity<Task>()
                .HasMany(t => t.EmployeeTimeSheets);
        }
    }
}
