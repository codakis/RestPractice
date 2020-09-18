using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestPractice.API.Helpers;
using RestPractice.API.Models;
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
       
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authors = _repository.GetAuthors();
            var authorsDto = new List<AuthorDto>();
            foreach (var authorDto in authors)
            {
                   authorsDto.Add(new AuthorDto()
                   {
                       Id = authorDto.Id,
                       Name = $"{authorDto.FirstName} {authorDto.LastName}",
                       MainCategory = authorDto.MainCategory,
                       Age = authorDto.DateOfBirth.GetCurrentAge()
                   }); 
            }
            return  Ok(authorsDto);
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