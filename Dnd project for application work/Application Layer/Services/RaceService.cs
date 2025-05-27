using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;
using Dnd_project_for_application_work.Infrastructure_Layer.Repositories;

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
        public async Task<RaceDto?> GetRaceByIdAsync(int id)
        {
            var c = await _RaceRepository.GetRaceByIdAsync(id);
            if (c == null) return null;

            return new RaceDto
            {
                RaceId = c.RaceId,
                RaceName = c.RaceName
            };
        }
    }
}
