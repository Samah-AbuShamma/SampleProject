using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingProject.Models
{
    public partial class StudentCourse
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("StudentCourse")]
        public virtual Course Course { get; set; }
        [ForeignKey("StudentId")]
        [InverseProperty("StudentCourse")]
        public virtual Student Student { get; set; }
    }
}
