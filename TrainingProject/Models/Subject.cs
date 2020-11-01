using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingProject.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        [StringLength(2000)]
        public string Name { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<Course> Course { get; set; }
    }
}
