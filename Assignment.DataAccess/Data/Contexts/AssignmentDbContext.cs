using Microsoft.EntityFrameworkCore;
using Assignment.DataAccess.Models;
namespace Assignment.DataAccess.Data.Contexts;

public class AssignmentDbContext : DbContext
{
    public DbSet<AssignmentModel> Assignments { get; set; }
    public DbSet<DepartmentModel> Departments { get; set; }
    public DbSet<EmployeeModel> Employees { get; set; }
    public DbSet<ProjectModel> Projects { get; set; }
    
    public AssignmentDbContext() {}
    
    public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Assignment;Trusted_Connection=True;");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentModel>(entity =>
        {
            entity.HasOne(a => a.Employee)
                .WithMany(e => e.Assignments)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(a => a.Project)
                .WithMany(p => p.Assignments)
                .HasForeignKey(a => a.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<EmployeeModel>(entity =>
        {
            entity.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<DepartmentModel>(entity =>
        {
            entity.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<ProjectModel>(entity =>
        {
            entity.HasMany(p => p.Assignments)
                .WithOne(a => a.Project)
                .HasForeignKey(a => a.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        base.OnModelCreating(modelBuilder);
    }
}