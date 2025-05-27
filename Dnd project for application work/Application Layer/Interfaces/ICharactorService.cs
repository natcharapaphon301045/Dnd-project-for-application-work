using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetAllCharactersAsync();
    }

    public class CharacterService : ICharacterService
    {
        
    }

}
