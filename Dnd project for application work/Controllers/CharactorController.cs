using Dnd_project_for_application_work.DbContext;
using Dnd_project_for_application_work.Domain_Layer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dnd_project_for_application_work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CharacterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            var characters = await _context.Characters
                .Include(c => c.Alignment)
                .Include(c => c.Class)
                .Include(c => c.Race)
                .ToListAsync();

            if (characters == null || !characters.Any())
                return NotFound();

            return Ok(characters);
        }
    }
}
