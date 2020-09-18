using AutoMapper;

namespace RestPractice.API.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Entities.Course, Models.CourseDto>();
        }
        
        
    }
}