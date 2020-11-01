using System.ComponentModel.DataAnnotations;

namespace TrainingProject.ViewModel
{
	public class StudentViewModel
	{
		public int Id { get; set; }
		[StringLength(2000)]
		public string Name { get; set; }

		public string CourseName { get; set; }
	}
}
