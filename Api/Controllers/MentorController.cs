using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mentor>>> GetAll()
        {
            var mentors = await _mentorService.GetAllAsync();
            return Ok(mentors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Mentor>> GetById(int id)
        {
            var mentor = await _mentorService.GetByIdAsync(id);
            if (mentor == null)
            {
                return NotFound();
            }
            return Ok(mentor);
        }

        [HttpGet("free/{scienceId:int}")]
        public async Task<ActionResult<List<Mentor>>> GetAllFreeByScienceId(int scienceId)
        {
            var mentors = await _mentorService.GetAllFreeByScienceIdAsync(scienceId);
            return Ok(mentors);
        }

        [HttpPost]
        public async Task<ActionResult<Mentor>> Create([FromBody] Mentor mentor)
        {
            var created = await _mentorService.CreateAsync(mentor);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Mentor mentor)
        {
            if (id != mentor.Id)
            {
                return BadRequest("Id mismatch");
            }
            var updated = await _mentorService.UpdateAsync(mentor);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _mentorService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}


