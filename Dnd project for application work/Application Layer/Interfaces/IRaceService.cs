using Dnd_project_for_application_work.Application_Layer.DTOs;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface IRaceService
    {
        Task<IEnumerable<RaceDto>> GetAllRaceAsync();
        Task<RaceDto?> GetRaceByIdAsync(int id);
        Task<RaceDto> CreateRaceAsync(RaceDto raceDto);
        Task<bool> UpdateRaceAsync(int id, RaceDto raceDto);
        Task<bool> DeleteRaceAsync(int id);
    }
}
