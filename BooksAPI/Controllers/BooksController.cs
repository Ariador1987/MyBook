using AutoMapper;
using BookAPI.Domain.Models;
using BookAPI.Domain.Models.DTOs;
using BookAPI.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    /// <summary>
    /// Endpoint for book-related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Returns all books
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            // TODO: Try catch i loggiranje


            var books = await _bookRepository.GetAll();

            if (books is null || books.Count() < 1)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booksDTO = _mapper.Map<IList<BookDTO>>(books);

            return StatusCode(200, booksDTO);
        }

        /// <summary>
        /// Returns a single book
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            // TODO: Try catch i loggiranje

            var book = await _bookRepository.FindById(id);

            if (book is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookDTO = _mapper.Map<BookDTO>(book);

            return StatusCode(200, bookDTO);
        }

        /// <summary>
        /// Create a single book
        /// </summary>
        /// <param name="bookDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] BookDTO bookDTO)
        {
            // TODO: Try catch i loggiranje

            var objToAdd = _mapper.Map<Book>(bookDTO);

            var isSuccess = await _bookRepository.Create(objToAdd);
            if (!isSuccess)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(201, objToAdd);
        }


        /// <summary>
        /// updates a single book.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(204)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDTO bookDTO)
        {
            // TODO: Try catch i loggiranje
            var isExsists = await _bookRepository.isExsists(id);
            if (!isExsists)
                return BadRequest();
            
            var book = _mapper.Map<Book>(bookDTO);

            if (book is null)
                return NotFound();
            if (book.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isSuccess = await _bookRepository.Update(book);
            if (!isSuccess)
            {
                return StatusCode(500, "Something went wrong please contact an administrator.");
            }

            return StatusCode(204);
        }

        /// <summary>
        /// Deletes a single book
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
            var isExsists = await _bookRepository.isExsists(id);
            if (!isExsists)
                return NotFound();

            var objToDelete = await _bookRepository.FindById(id);
            if (objToDelete.Id != id)
                return BadRequest();

            var isSuccess = await _bookRepository.Delete(objToDelete);
            if (!isSuccess)
                return StatusCode(500, ModelState);

            return StatusCode(204);
        }
    }
}
