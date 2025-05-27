using Dnd_project_for_application_work.Application_Layer.DTOs;
using System.Threading.Tasks;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetAllCharactersAsync();
        Task<CharacterDto?> GetCharacterByIdAsync(int id);
        Task<ApiResponse<CharacterDto>> CreateCharacterAsync(CreateCharacterDto characterDto);
        
        Task<bool> DeleteCharacterAsync(int id);
    }
}
