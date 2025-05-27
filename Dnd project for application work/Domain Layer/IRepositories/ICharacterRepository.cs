using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dnd_project_for_application_work.Domain_Layer.IRepositories
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllCharacterAsync();
        /*Task<Character?> GetByIdAsync(int id);
        Task AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(int id);*/
    }
}
