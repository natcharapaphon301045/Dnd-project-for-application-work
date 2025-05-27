using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dnd_project_for_application_work.Domain_Layer.IRepositories
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllCharacterAsync();
        Task<Character?> GetCharacterByIdAsync(int id);
        Task CreateCharacterAsync(Character character);
        Task UpdateCharacterAsync(Character character);
        Task DeleteCharacterAsync(int id);
    }
}
