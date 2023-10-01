using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class IttemContext : DbContext
{
    public IttemContext(DbContextOptions<IttemContext> options) : base(options)
    { }

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