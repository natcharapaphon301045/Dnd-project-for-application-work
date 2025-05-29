using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Application_Layer.Interfaces;
using Dnd_project_for_application_work.Application_Layer.Services;
using Dnd_project_for_application_work.Infrastructure_Layer.Persistence_DbContext;
using Microsoft.AspNetCore.Mvc;
namespace Dnd_project_for_application_work.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaticDataController : ControllerBase
    {
        private readonly AlignmentService _alignmentService;
        private readonly RaceService _raceService;
        private readonly ClassService _classService;

        public StaticDataController(
            AlignmentService alignmentService,
            RaceService raceService,
            ClassService classService)
        {
            _alignmentService = alignmentService;
            _raceService = raceService;
            _classService = classService;
        }

        [HttpGet("Alignment")]
        public async Task<IActionResult> GetAlignments()
        {
            var result = await _alignmentService.GetAllAlignmentAsync();
            return Ok(new { data = result });
        }

        [HttpGet("Race")]
        public async Task<IActionResult> GetRaces()
        {
            var result = await _raceService.GetAllRaceAsync();
            return Ok(new { data = result });
        }

        [HttpGet("Class")]
        public async Task<IActionResult> GetClasses()
        {
            var result = await _classService.GetAllClassAsync();
            return Ok(new { data = result });
        }
    }
}
