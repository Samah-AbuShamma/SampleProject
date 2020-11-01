using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Models;
using TrainingProject.ViewModel;

namespace TrainingProject.Controllers
{
	[Route("api/[controller]")]
	public class StudentController : Controller
	{
		IMapper _mapper; 
		public StudentController(IMapper mapper)
		{
			_mapper = mapper; 
		}

		[HttpGet("[action]")]
		public List<Student> GetStudentsList()
		{
			var db = new TrainingDBContext();
			return db.Student.ToList();
		}


		[HttpPost("[action]")]
		public async Task<IActionResult> AddNewStudent([FromBody] Student student)
		{
			var db = new TrainingDBContext();
			try
			{
				await db.AddAsync(student);
				await db.SaveChangesAsync();
				return Ok(student);
			}
			catch (Exception ex)
			{
				return Json(new { Success = false, Message = ex.Message });
			}
		}

		[HttpGet("[action]")]
		public IActionResult GetStudentInfo(int id)
		{
			var db = new TrainingDBContext();
			var student = db.Student.Find(id);
			var studentVm = new StudentViewModel { };
			studentVm = _mapper.Map<StudentViewModel>(student);
			studentVm.CourseName = db.StudentCourse.AsQueryable()
									.Include(ops=>ops.Course)
									.Where(course => course.StudentId == id).Select(course=>course.Course.Name).FirstOrDefault();

			return Ok(studentVm); 
		}
	}
}
