using System;
using Microsoft.AspNetCore.Mvc;
using RestPractice.API.Services;

namespace RestPractice.API.Controllers
{
    [ApiController]
    public class AuthorsController :ControllerBase
    {
        private readonly ICourseLibraryRepository _repository;

        public AuthorsController(ICourseLibraryRepository repository)
        {
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
        }
        public IActionResult GetAuthors()
        {
            var authors = _repository.GetAuthors();
            return new JsonResult(authors);
        }
    }
}