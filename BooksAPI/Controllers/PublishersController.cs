using AutoMapper;
using BookAPI.Domain.Models;
using BookAPI.Domain.Models.DTOs;
using BookAPI.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace PublishersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublishersController(IPublisherRepository PublisherRepository,
            IMapper mapper)
        {
            _publisherRepository = PublisherRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Returns all Publishers
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            // TODO: Try catch i loggiranje
            var Publishers = await _publisherRepository.GetAll();

            if (Publishers is null || Publishers.Count() < 1)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var PublishersDTO = _mapper.Map<IList<PublisherDTO>>(Publishers);

            return StatusCode(200, PublishersDTO);
        }

        /// <summary>
        /// Returns a single Publisher
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            // TODO: Try catch i loggiranje

            var Publisher = await _publisherRepository.FindById(id);

            if (Publisher is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var PublisherDTO = _mapper.Map<PublisherDTO>(Publisher);

            return StatusCode(200, PublisherDTO);
        }

        /// <summary>
        /// Create a single Publisher
        /// </summary>
        /// <param name="PublisherDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] PublisherDTO PublisherDTO)
        {
            // TODO: Try catch i loggiranje

            var objToAdd = _mapper.Map<Publisher>(PublisherDTO);

            var isSuccess = await _publisherRepository.Create(objToAdd);
            if (!isSuccess)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(201, objToAdd);
        }


        /// <summary>
        /// updates a single Publisher.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PublisherDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(204)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] PublisherUpdateDTO PublisherDTO)
        {
            // TODO: Try catch i loggiranje
            var isExsists = await _publisherRepository.isExsists(id);
            if (!isExsists)
                return BadRequest();

            var Publisher = _mapper.Map<Publisher>(PublisherDTO);

            if (Publisher is null)
                return NotFound();
            if (Publisher.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isSuccess = await _publisherRepository.Update(Publisher);
            if (!isSuccess)
            {
                return StatusCode(500, "Something went wrong please contact an administrator.");
            }

            return StatusCode(204);
        }

        /// <summary>
        /// Deletes a single Publisher
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
            var isExsists = await _publisherRepository.isExsists(id);
            if (!isExsists)
                return NotFound();

            var objToDelete = await _publisherRepository.FindById(id);
            if (objToDelete.Id != id)
                return BadRequest();

            var isSuccess = await _publisherRepository.Delete(objToDelete);
            if (!isSuccess)
                return StatusCode(500, ModelState);

            return StatusCode(204);
        }
    }
}
