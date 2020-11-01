using AutoMapper;
using TrainingProject.Models;

namespace TrainingProject.ViewModel
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<StudentViewModel, Student>().ReverseMap();
			CreateMap<StudentViewModel, Student>().ReverseMap();
		}

	}
}
