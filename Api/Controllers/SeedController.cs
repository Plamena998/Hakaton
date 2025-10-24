using Infrastructure.Enums;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly IScienceService _scienceService;
        private readonly IMentorService _mentorService;

        public SeedController(IScienceService scienceService, IMentorService mentorService)
        {
            _scienceService = scienceService;
            _mentorService = mentorService;
        }

        [HttpPost("sciences")]
        public async Task<ActionResult<List<Science>>> SeedSciences()
        {
            var desired = new List<string> { "Physics", "Mathematics", "Chemistry", "Biology" };
            var existing = await _scienceService.GetAllAsync();
            var existingNames = new HashSet<string>(existing.Select(s => s.Name));

            var created = new List<Science>();
            foreach (var name in desired)
            {
                if (!existingNames.Contains(name))
                {
                    var science = await _scienceService.CreateAsync(new Science { Name = name });
                    created.Add(science);
                }
            }

            var all = await _scienceService.GetAllAsync();
            return Ok(new
            {
                createdCount = created.Count,
                totalCount = all.Count,
                sciences = all
            });
        }

        [HttpPost("mentors")]
        public async Task<ActionResult> SeedMentors()
        {
            // Ensure sciences exist
            var sciences = await _scienceService.GetAllAsync();
            if (sciences.Count == 0)
            {
                await SeedSciences();
                sciences = await _scienceService.GetAllAsync();
            }

            var mentorsExisting = await _mentorService.GetAllAsync();
            if (mentorsExisting.Count >= 20)
            {
                return Ok(new { createdCount = 0, totalCount = mentorsExisting.Count, message = "Already seeded 20+ mentors" });
            }

            var rnd = new Random();
            var uniNames = new[] { "Tech University", "National University", "State University", "Polytechnic Institute", "City College" };
            var levels = Enum.GetValues(typeof(Level)).Cast<Level>().ToArray();

            var created = new List<Mentor>();
            for (int i = mentorsExisting.Count; i < 20; i++)
            {
                var science = sciences[i % sciences.Count];
                var mentor = new Mentor
                {
                    Name = $"Mentor {i + 1}",
                    UniName = uniNames[rnd.Next(uniNames.Length)],
                    Distance = Math.Round(rnd.NextDouble() * 100, 2),
                    Level = levels[rnd.Next(levels.Length)],
                    ScienceId = science.Id,
                    // Set to dates in the past so mentor is free per today's logic
                    BeforeLastProcedureDate = DateTime.UtcNow.Date.AddDays(-10 - rnd.Next(20)),
                    LastProcedureDate = DateTime.UtcNow.Date.AddDays(-5 - rnd.Next(10))
                };
                var createdMentor = await _mentorService.CreateAsync(mentor);
                created.Add(createdMentor);
            }

            var all = await _mentorService.GetAllAsync();
            return Ok(new { createdCount = created.Count, totalCount = all.Count, mentors = created });
        }
    }
}


