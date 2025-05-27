using Dnd_project_for_application_work.Application_Layer.DTOs;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetAllCharactersAsync();
        Task<CharacterDto?> GetCharacterByIdAsync(int id);
        Task<ApiResponse<CharacterDto>> CreateCharacterAsync(CreateCharacterDto characterDto);
        Task<ApiResponse<CharacterDto>> UpdateCharacterAsync(UpdateCharacterDto updateCharacterDto);
        Task<bool> DeleteCharacterAsync(int id);
    }
}
