using Microsoft.AspNetCore.Mvc;
using Oceans11.DataRepository;
using Oceans11.Models;
using Oceans11.Models.DTO;

namespace Oceans11.Controllers
{
    [Route("api/heistmembers")]
    [ApiController]
    public class HeistMemberController : ControllerBase
    {
        private readonly IDataRepository<HeistMember, HeistMemberDTO> _dataRepository;

        public HeistMemberController( IDataRepository<HeistMember, HeistMemberDTO>dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Authors
        [HttpGet]
        public IActionResult Get()
        {
            var authors = _dataRepository.GetAll();
            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            var author = _dataRepository.Get(id);
            if (author == null)
            {
                return NotFound("Author not found.");
            }

            return Ok(author);
        }

        // POST: api/Authors
        [HttpPost]
        public ActionResult<HeistMemberDTO> Post([FromBody] HeistMember heistMember)
        {
            if (heistMember == null)
            {
                return BadRequest("Author is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(heistMember);

            return CreatedAtRoute("GetAuthor", new { Id = heistMember.Id },heistMember);
        }
        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HeistMember heistMember)
        {
            if (heistMember == null)
            {
                return BadRequest("Author is null.");
            }

            var authorToUpdate = _dataRepository.Get(id);
            if (authorToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(authorToUpdate, heistMember);
            return NoContent();
        }
    }
}
