using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static ConsoleApp7.Models.StudentEntity;
using static ConsoleApp7.Models.ClassroomsEntity;
using static ConsoleApp7.Models.AcademicsubjEntity;
using static ConsoleApp7.Models.ExamEntity;

class ApplicationContext : DbContext
{



    public ApplicationContext()
    {
    }

    public DbSet<Classrooms> classrooms { get; set; }
    public DbSet<Student> students { get; set; }
    public DbSet<Academicsubj> academicsubj { get; set; }
    public DbSet<Exam> exam { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DB3;Username=postgres;Password=1234");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

}
