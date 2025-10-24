using DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IDistanceService distanceService;
        private readonly HakDbContext db;

        public TestController(IDistanceService distanceService,HakDbContext db)
        {
            this.distanceService = distanceService;
            this.db = db;
        }
        [HttpGet("distance")]
        public IActionResult GetShortestDistance()
        {

            return Ok(distanceService.ClosestDistance(db.mentors.ToList()));
        }
    }
}
