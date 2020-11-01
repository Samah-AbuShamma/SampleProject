using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingProject.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public int? SubjectId { get; set; }
        [StringLength(2000)]
        public string Name { get; set; }

        [ForeignKey("SubjectId")]
        [InverseProperty("Course")]
        public virtual Subject Subject { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
