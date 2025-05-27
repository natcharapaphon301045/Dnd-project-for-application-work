using System.Collections.Generic;
using System.Threading.Tasks;
using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Domain_Layer.IRepositories
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAllRaceAsync();
        Task<Race?> GetRaceByIdAsync(int id);
    }
}