using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;

namespace Dnd_project_for_application_work.Application_Layer.Services
{
    public class RaceService
    {
        private readonly IRaceRepository _RaceRepository;

        public RaceService(IRaceRepository RaceRepository)
        {
            _RaceRepository = RaceRepository;
        }

        public async Task<IEnumerable<RaceDto>> GetAllRaceAsync()
        {
            var Races = await _RaceRepository.GetAllRaceAsync();

            return Races.Select(c => new RaceDto
            {
                RaceId = c.RaceId,
                RaceName = c.RaceName
            });
        }
    }
}
