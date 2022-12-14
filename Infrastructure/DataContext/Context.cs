
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Context;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext>options):base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
 
    
            
                modelBuilder.Entity<Enrollment>()
            .HasOne<Student>(s => s.student)
            .WithMany(g => g.Enrollments)
            .HasForeignKey(s => s.EnrolmentID);

              modelBuilder.Entity<Enrollment>()
            .HasOne<Course>(s => s.course)
            .WithMany(g => g.Enrollments)
            .HasForeignKey(s => s.EnrolmentID);
    }
    public DbSet<Student> Students{get;set;}
        public DbSet<Course> Courses{get;set;}
            public DbSet<Enrollment> Enrollments{get;set;}


}
