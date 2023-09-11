using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp7.Models.StudentEntity;
using static ConsoleApp7.Models.ExamEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp7.Models
{
    class AcademicsubjEntity
    {
        public class Academicsubj
        {
            public Academicsubj()
            {
                exam = new List<Exam>();
            }

            [Key]
            public int academicsub { get; set; }
            public string name { get; set; }

            public virtual List<Exam> exam { get; set; }
            public override string ToString()
            {
                return $"Academic subject = {name}";
            }
        }
    }

}
