using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestPractice.API.Models;
using RestPractice.API.Services;

namespace RestPractice.API.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository _repository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseLibraryRepository repository, IMapper mapper)
        {
            _repository = repository ?? 
                          throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }
        // GET
        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesForAuthor(Guid authorId)
        {
            if (!_repository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var coursesForAuthor = _repository.GetCourses(authorId);
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(coursesForAuthor)); 
        }

        [HttpGet("{courseId}")]
        public ActionResult<CourseDto> GetCourseForAuthor(Guid authorId, Guid courseId)
        {
            if (!_repository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courseFromRepo = _repository.GetCourse(authorId, courseId);
            if (courseFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CourseDto>(courseFromRepo));
        }
    }
}