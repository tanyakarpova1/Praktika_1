using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationContext;
using static ConsoleApp7.Models.ExamEntity;
using static ConsoleApp7.Models.ClassroomsEntity;

namespace ConsoleApp7.Models
{
    class StudentEntity
    {
        public class Student
        {
            public Student()
            {
                exam = new List<Exam>();
            }
            [Key]
            public int studentid { get; set; }
            public string name { get; set; }
            public int classroom_id { get; set; }
            public Classrooms classroom_ { get; set; }
            public virtual List<Exam> exam { get; set; }
            public override string ToString()
            {
                return $"Student: name = {name}, classrom_id = {classroom_id}";
            }
        }
    }
}

