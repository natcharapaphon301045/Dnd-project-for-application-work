using Dnd_project_for_application_work.Application_Layer.Interfaces;
using Dnd_project_for_application_work.DbContext;
using Microsoft.AspNetCore.Mvc;

namespace Dnd_project_for_application_work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICharacterService _characterService;

        public CharacterController(AppDbContext context, ICharacterService characterService)
        {
            _context = context;
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();
            return Ok(characters);
        }
    }
}
