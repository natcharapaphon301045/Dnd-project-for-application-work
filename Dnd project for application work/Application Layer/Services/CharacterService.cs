using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Application_Layer.Interfaces;
using Dnd_project_for_application_work.Domain_Layer;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;
using Dnd_project_for_application_work.Infrastructure_Layer.Repositories;

namespace Dnd_project_for_application_work.Application_Layer.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _CharacterRepository;
        private readonly IAlignmentRepository _AlignmentRepository;
        private readonly IRaceRepository _RaceRepository;
        private readonly IClassRepository _ClassRepository;
        public CharacterService(
            ICharacterRepository characterRepository,
            IAlignmentRepository alignmentRepository,
            IRaceRepository raceRepository,
            IClassRepository classRepository)
        {
            _CharacterRepository = characterRepository;
            _AlignmentRepository = alignmentRepository;
            _RaceRepository = raceRepository;
            _ClassRepository = classRepository;
        }
        public async Task<IEnumerable<CharacterDto>> GetAllCharactersAsync()
        {
            var characters = await _CharacterRepository.GetAllCharacterAsync();

            return characters.Select(c => new CharacterDto
            {
                CharacterId = c.CharacterId,
                CharacterName = c.CharacterName,
                AlignmentName = c.Alignment?.AlignmentName ?? "Unknown",
                ClassName = c.Class?.ClassName ?? "Unknown",
                RaceName = c.Race?.RaceName ?? "Unknown"
            });
        }
        public async Task<CharacterDto?> GetCharacterByIdAsync(int id)
        {
            var c = await _CharacterRepository.GetCharacterByIdAsync(id);
            if (c == null) return null;

            return new CharacterDto
            {
                CharacterId = c.CharacterId,
                CharacterName = c.CharacterName,
                AlignmentName = c.Alignment?.AlignmentName ?? "Unknown",
                ClassName = c.Class?.ClassName ?? "Unknown",
                RaceName = c.Race?.RaceName ?? "Unknown"
            };
        }
        public async Task<ApiResponse<CharacterDto>> CreateCharacterAsync(CreateCharacterDto characterDto)
        {
            var alignment = await _AlignmentRepository.GetAlignmentByIdAsync(characterDto.AlignmentId);
            var race = await _RaceRepository.GetRaceByIdAsync(characterDto.RaceId);
            var classEntity = await _ClassRepository.GetClassByIdAsync(characterDto.ClassId);

            if (alignment == null)
                return new ApiResponse<CharacterDto>(false, "Alignment not found", null);
            if (race == null)
                return new ApiResponse<CharacterDto>(false, "Race not found", null);
            if (classEntity == null)
                return new ApiResponse<CharacterDto>(false, "Class not found", null);

            var character = new Character
            {
                CharacterName = characterDto.CharacterName,
                AlignmentId = characterDto.AlignmentId,
                ClassId = characterDto.ClassId,
                RaceId = characterDto.RaceId
            };

            await _CharacterRepository.CreateCharacterAsync(character);

            var result = new CharacterDto
            {
                CharacterId = character.CharacterId,
                CharacterName = character.CharacterName,
                AlignmentName = alignment.AlignmentName,
                RaceName = race.RaceName,
                ClassName = classEntity.ClassName
            };

            return new ApiResponse<CharacterDto>(true, "Character created successfully", result);
        }

        //Update character
        public async Task<ApiResponse<CharacterDto>> UpdateCharacterAsync(UpdateCharacterDto dto)
        {
            var character = await _CharacterRepository.GetCharacterByIdAsync(dto.CharacterId);
            if (character == null)
                return new ApiResponse<CharacterDto>(false, "Character not found", null);

            if (dto.CharacterName != null)
                character.CharacterName = dto.CharacterName;

            if (dto.AlignmentId.HasValue)
            {
                var alignment = await _AlignmentRepository.GetAlignmentByIdAsync(dto.AlignmentId.Value);
                if (alignment == null)
                    return new ApiResponse<CharacterDto>(false, "Alignment not found", null);
                character.AlignmentId = dto.AlignmentId.Value;
            }

            if (dto.RaceId.HasValue)
            {
                var race = await _RaceRepository.GetRaceByIdAsync(dto.RaceId.Value);
                if (race == null)
                    return new ApiResponse<CharacterDto>(false, "Race not found", null);
                character.RaceId = dto.RaceId.Value;
            }

            if (dto.ClassId.HasValue)
            {
                var classEntity = await _ClassRepository.GetClassByIdAsync(dto.ClassId.Value);
                if (classEntity == null)
                    return new ApiResponse<CharacterDto>(false, "Class not found", null);
                character.ClassId = dto.ClassId.Value;
            }

            await _CharacterRepository.UpdateCharacterAsync(character);

            var alignmentName = (await _AlignmentRepository.GetAlignmentByIdAsync(character.AlignmentId))?.AlignmentName ?? "";
            var raceName = (await _RaceRepository.GetRaceByIdAsync(character.RaceId))?.RaceName ?? "";
            var className = (await _ClassRepository.GetClassByIdAsync(character.ClassId))?.ClassName ?? "";

            var updatedDto = new CharacterDto
            {
                CharacterId = character.CharacterId,
                CharacterName = character.CharacterName,
                AlignmentName = alignmentName,
                RaceName = raceName,
                ClassName = className
            };

            return new ApiResponse<CharacterDto>(true, "Character updated successfully", updatedDto);
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var character = await _CharacterRepository.GetCharacterByIdAsync(id);
            if (character == null) return false;

            await _CharacterRepository.DeleteCharacterAsync(id);
            return true;
        }
    }
}
