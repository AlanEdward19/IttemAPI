using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class IttemContext : DbContext
{
    public IttemContext(DbContextOptions<IttemContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Attendances)
            .WithOne(a => a.Student)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.Assessments)
            .WithOne(a => a.Student)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.CertificateIssuances)
            .WithOne(ci => ci.Student)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Class>()
            .HasMany(c => c.Students)
            .WithOne(s => s.Class)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.Students)
            .WithOne(s => s.Company)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Function>()
            .HasMany(f => f.Students)
            .WithOne(s => s.Function)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Polo)
            .WithMany(p => p.Students)
            .HasForeignKey(s => s.PoloId)
            .OnDelete(DeleteBehavior.SetNull);

        // Adicione outras configurações do modelo conforme necessário...

        base.OnModelCreating(modelBuilder);
    }


    #region DbSets

    public DbSet<Assessment> Assessments { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<CertificateIssuance> CertificateIssuances { get; set;}
    public DbSet<Class> Classes { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Function> Functions { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Polo> Polos { get; set; }
    public DbSet<Student> Students { get; set; }

    #endregion
}