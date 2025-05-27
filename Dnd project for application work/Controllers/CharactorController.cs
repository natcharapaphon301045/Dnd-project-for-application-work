using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Application_Layer.Interfaces;
using Dnd_project_for_application_work.Application_Layer.Services;
using Dnd_project_for_application_work.Infrastructure_Layer.Persistence_DbContext;
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

            if (characters == null || !characters.Any())
                return NotFound(new ApiResponse<string>("ไม่พบข้อมูลตัวละคร"));

            return Ok(new ApiResponse<IEnumerable<CharacterDto>>(characters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);

            if (character == null)
                return NotFound(new ApiResponse<string>("ไม่พบตัวละครที่มี ID นี้"));

            return Ok(new ApiResponse<CharacterDto>(character));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacterDto CreateCharacterDto)
        {
            var response = await _characterService.CreateCharacterAsync(CreateCharacterDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, [FromBody] UpdateCharacterDto dto)
        {
            if (id != dto.CharacterId)
                return BadRequest("Mismatched CharacterId");

            var response = await _characterService.UpdateCharacterAsync(dto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var deleted = await _characterService.DeleteCharacterAsync(id);

            if (!deleted)
                return NotFound(new ApiResponse<string>("ไม่พบตัวละครเพื่อทำการลบ"));

            return Ok(new ApiResponse<string>("ลบตัวละครเรียบร้อยแล้ว"));
        }
        
    }
}
