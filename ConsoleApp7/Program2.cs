using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ConsoleApp7.Models.AcademicsubjEntity;
using static ConsoleApp7.Models.ClassroomsEntity;
using static ConsoleApp7.Models.ExamEntity;
using static ConsoleApp7.Models.StudentEntity;

class Program2
{
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
                    List<string> list = (new string[] { "Математика", "Физика", "Информатика" }).ToList();
                    String ABJ = list[new Random().Next(list.Count)];
                    Academicsubj academicsubj = new Academicsubj { name = ABJ };
                    List<string> list2 = (new string[] { "Ильина Александра Рудольфовна", "Медведева Таисия Дмитрьевна", "Никитина Юланта Тихоновна", "Фомина Аюна Евсеевна", "Лукина Гражина Куприяновна" }).ToList();
                    String teacher4 = list[new Random().Next(list.Count)];
                    Classrooms classrooms = new Classrooms { teacher = teacher4 };
                    List<string> list3 = (new string[] { "Шарапов Борис", "Евгений Германнович", " Никифор Николаевич", "Валерия Егоровна", "Дарьяна Валентиновна" }).ToList();
                    String name2 = list[new Random().Next(list.Count)];
                    Student student = new Student { name = name2 };
                    Exam exam5 = new Exam { name = ABJ };
                    classrooms.students.Add(student);
                    student.exam.Add(exam5);
                    academicsubj.exam.Add(exam5);
                    applicationContext.classrooms.Add(classrooms);
                    applicationContext.students.Add(student);
                    applicationContext.academicsubj.Add(academicsubj);
                    applicationContext.exam.Add(exam5);
                    applicationContext.SaveChanges();
                    Console.WriteLine($"Вы добавили новый экзамен: {ABJ}");
                }

                break;
        }
    }
}