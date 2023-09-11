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



    static void Main()
    {
        using (ApplicationContext applicationContext = new ApplicationContext())
        {
            Classrooms classrooms1 = new Classrooms { teacher = "Фролов Константин Иванович" };
            Classrooms classrooms2 = new Classrooms { teacher = "Кузнецов Илья Степанович" };
            Classrooms classrooms3 = new Classrooms { teacher = "Соколова Екатерина Михайловна" };

            Student student1 = new Student { name = "Анна Попова" };
            Student student2 = new Student { name = "Анастасия Афанасьева" };
            Student student3 = new Student { name = "Евгений Соловьев" };
            Student student4 = new Student { name = "Сергей Морозов" };
            Student student5 = new Student { name = "Игорь Воробьев" };
            Student student6 = new Student { name = "Анжелика Голубева" };
            Student student7 = new Student { name = "Наталья Орлова" };

            Academicsubj academicsubj1 = new Academicsubj { name = "Математика" };
            Academicsubj academicsubj2 = new Academicsubj { name = "Информатика" };
            Academicsubj academicsubj3 = new Academicsubj { name = "Физика" };


            Exam exam1 = new Exam { name = "Экзамен по математике" };
            Exam exam2 = new Exam { name = "Экзамен по информатике" };
            Exam exam3 = new Exam { name = "Экзамен по физике" };

            classrooms1.students.Add(student1);
            classrooms2.students.Add(student3);
            classrooms3.students.Add(student2);
            classrooms1.students.Add(student5);
            classrooms2.students.Add(student7);
            classrooms3.students.Add(student6);

            student1.exam.Add(exam1);
            student2.exam.Add(exam1);
            student3.exam.Add(exam2);
            student4.exam.Add(exam2);
            student5.exam.Add(exam3);
            student6.exam.Add(exam2);
            student7.exam.Add(exam3);

            academicsubj1.exam.Add(exam1);
            academicsubj2.exam.Add(exam2);
            academicsubj3.exam.Add(exam3);



            applicationContext.SaveChanges();

        }

        Console.WriteLine("Выберите функцию и нажмите соотвествующую цифру");
        Console.WriteLine("_______________________________________________");
        Console.WriteLine("\t1 - Вывести список экзаменов");
        Console.WriteLine("\t2 - Добавить новый экзамен");
        switch (Console.ReadLine())
        {
            case "1":
                using (ApplicationContext applicationContext = new ApplicationContext())
                {
                    List<Exam> exam = applicationContext.exam.ToList();
                    foreach (Exam e in exam)
                    {
                        Console.WriteLine(e);

                    }
                }
                break;

            case "2":
                using (ApplicationContext applicationContext = new ApplicationContext())
                {
                    Console.WriteLine("Введите название предмета");
                    string? name1 = Console.ReadLine();
                    Academicsubj academicsubj = new Academicsubj { name = name1 };
                    Console.WriteLine("Имя и фамилию ученика");
                    string? name2 = Console.ReadLine();
                    Console.WriteLine("Введите ФИО учителя");
                    string? teacher4 = Console.ReadLine();
                    Classrooms classrooms = new Classrooms { teacher = teacher4 };
                    Student student = new Student { name = name2 };
                    Exam exam = new Exam { name = name1 };
                    classrooms.students.Add(student);
                    student.exam.Add(exam);
                    academicsubj.exam.Add(exam);
                    applicationContext.classrooms.Add(classrooms);
                    applicationContext.students.Add(student);
                    applicationContext.academicsubj.Add(academicsubj);
                    applicationContext.exam.Add(exam);
                    applicationContext.SaveChanges();
                    Console.WriteLine($"Вы добавили новый экзамен: {name1}");
                }
                break;
        }
    }
}
