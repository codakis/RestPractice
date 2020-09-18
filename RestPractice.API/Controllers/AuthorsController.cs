using System;
using Microsoft.AspNetCore.Mvc;
using RestPractice.API.Services;

namespace RestPractice.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
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
            return  Ok(authors);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {            
            var author = _repository.GetAuthor(authorId);

            if (author ==null)
                return NotFound();
   
            // if (!_repository.AuthorExists(authorId))
            // {
            //     return NotFound();
            // }
            return Ok(author);
        }
    }
}