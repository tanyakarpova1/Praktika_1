using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationContext;
using static ConsoleApp7.Models.StudentEntity;

namespace ConsoleApp7.Models
{

    class ClassroomsEntity
    {
        public class Classrooms
        {
            public Classrooms()
            {
                students = new List<Student>();
            }
            public int id { get; set; }
            public string teacher { get; set; }

            public virtual List<Student> students { get; set; }
            public override string ToString()
            {
                return $"classroom: teacher = {teacher}";
            }
        }
    }
}