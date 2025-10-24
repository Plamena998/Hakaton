using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScienceController : ControllerBase
    {
        private readonly IScienceService _scienceService;

        public ScienceController(IScienceService scienceService)
        {
            _scienceService = scienceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Science>>> GetAll()
        {
            var sciences = await _scienceService.GetAllAsync();
            return Ok(sciences);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Science>> GetById(int id)
        {
            var science = await _scienceService.GetByIdAsync(id);
            if (science == null)
            {
                return NotFound();
            }
            return Ok(science);
        }

        [HttpPost]
        public async Task<ActionResult<Science>> Create([FromBody] Science science)
        {
            var created = await _scienceService.CreateAsync(science);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Science science)
        {
            if (id != science.Id)
            {
                return BadRequest("Id mismatch");
            }
            var updated = await _scienceService.UpdateAsync(science);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _scienceService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}


