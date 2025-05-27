using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Application_Layer.Interfaces;
using Dnd_project_for_application_work.Domain_Layer;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;

namespace Dnd_project_for_application_work.Application_Layer.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<IEnumerable<CharacterDto>> GetAllCharactersAsync()
        {
            var characters = await _characterRepository.GetAllCharacterAsync();

            return characters.Select(c => new CharacterDto
            {
                CharacterId = c.CharacterId,
                CharacterName = c.CharacterName,
                AlignmentName = c.AlignmentName,
                ClassName = c.ClassName,
                RaceName = c.Race?.Name
            });
        }

        /*
        public async Task<CharacterDto?> GetCharacterByIdAsync(int id)
        {
            var c = await _characterRepository.GetByIdAsync(id);
            if (c == null) return null;

            return new CharacterDto
            {
                CharacterId = c.CharacterId,
                CharacterName = c.CharacterName,
                AlignmentName = c.Alignment?.Name ?? "Unknown",
                ClassName = c.Class?.Name ?? "Unknown",
                RaceName = c.Race?.Name ?? "Unknown"
            };
        }*/
        /*
        public async Task<CharacterDto> CreateCharacterAsync(CreateCharacterDto dto)
        {
            var character = new Character
            {
                CharacterName = dto.CharacterName,
                AlignmentId = dto.AlignmentId,
                ClassId = dto.ClassId,
                RaceId = dto.RaceId
            };

            await _characterRepository.AddAsync(character);

            return new CharacterDto
            {
                CharacterId = character.CharacterId,
                CharacterName = character.CharacterName,
                AlignmentName = "", // optional: fill after include
                ClassName = "",
                RaceName = ""
            };
        }*/
        /*
        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterDto dto)
        {
            var character = await _characterRepository.GetByIdAsync(id);
            if (character == null) return false;

            character.CharacterName = dto.CharacterName;
            character.AlignmentId = dto.AlignmentId;
            character.ClassId = dto.ClassId;
            character.RaceId = dto.RaceId;

            await _characterRepository.UpdateAsync(character);
            return true;
        }*/
        /*
        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var character = await _characterRepository.GetByIdAsync(id);
            if (character == null) return false;

            await _characterRepository.DeleteAsync(id);
            return true;
        }*/
    }
}
