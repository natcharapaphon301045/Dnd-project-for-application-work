using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dnd_project_for_application_work.DbContext; // ต้องใช้ namespace ที่คุณสร้าง ApplicationDbContext ไว้
using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }
        /*
        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await _context.Characters
                .Include(c => c.Race)
                .Include(c => c.Class)
                .Include(c => c.Alignment)
                .ToListAsync();

            return Ok(characters);
        }
        */
        // เพิ่ม Create, Update, Delete ได้ภายหลัง
    }
}
