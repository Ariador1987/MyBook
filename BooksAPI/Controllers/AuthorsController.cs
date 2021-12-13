using AutoMapper;
using BookAPI.Domain.Models;
using BookAPI.Domain.Models.DTOs;
using BookAPI.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsAPI.Controllers
{
    /// <summary>
    /// Endpoint for Author-related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository AuthorRepository,
            IMapper mapper)
        {
            _authorRepository = AuthorRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Returns all Authors
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            // TODO: Try catch i loggiranje

            var Authors = await _authorRepository.GetAll();

            if (Authors is null || Authors.Count() < 1)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var AuthorsDTO = _mapper.Map<IList<AuthorDTO>>(Authors);

            return StatusCode(200, AuthorsDTO);
        }

        /// <summary>
        /// Returns a single Author
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            // TODO: Try catch i loggiranje

            var Author = await _authorRepository.FindById(id);

            if (Author is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var AuthorDTO = _mapper.Map<AuthorDTO>(Author);

            return StatusCode(200, AuthorDTO);
        }

        /// <summary>
        /// Create a single Author
        /// </summary>
        /// <param name="AuthorDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] AuthorDTO AuthorDTO)
        {
            // TODO: Try catch i loggiranje

            var objToAdd = _mapper.Map<Author>(AuthorDTO);

            var isSuccess = await _authorRepository.Create(objToAdd);
            if (!isSuccess)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(201, objToAdd);
        }


        /// <summary>
        /// updates a single Author.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="AuthorDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(204)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AuthorUpdateDTO AuthorDTO)
        {
            // TODO: Try catch i loggiranje
            var isExsists = await _authorRepository.isExsists(id);
            if (!isExsists)
                return BadRequest();

            var Author = _mapper.Map<Author>(AuthorDTO);

            if (Author is null)
                return NotFound();
            if (Author.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isSuccess = await _authorRepository.Update(Author);
            if (!isSuccess)
            {
                return StatusCode(500, "Something went wrong please contact an administrator.");
            }

            return StatusCode(204);
        }

        /// <summary>
        /// Deletes a single Author
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isExsists = await _authorRepository.isExsists(id);
            if (!isExsists)
                return NotFound();

            var objToDelete = await _authorRepository.FindById(id);
            if (objToDelete.Id != id)
                return BadRequest();

            var isSuccess = await _authorRepository.Delete(objToDelete);
            if (!isSuccess)
                return StatusCode(500, ModelState);

            return StatusCode(204);
        }
    }

}
