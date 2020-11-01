using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingProject.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        [StringLength(2000)]
        public string Name { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
