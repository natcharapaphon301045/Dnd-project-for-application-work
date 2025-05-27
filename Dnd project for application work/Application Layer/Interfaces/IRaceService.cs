using Dnd_project_for_application_work.Application_Layer.DTOs;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface IRaceService
    {
        Task<IEnumerable<RaceDto>> GetAllRaceAsync();
        /*Task<RaceDto?> GetByIdAsync(int id);
        Task<RaceDto> CreateRaceAsync(CreateRaceDto dto);
        Task<bool> UpdateRaceAsync(int id, UpdateRaceDto dto);
        Task<bool> DeleteRaceAsync(int id);*/
    }
}
