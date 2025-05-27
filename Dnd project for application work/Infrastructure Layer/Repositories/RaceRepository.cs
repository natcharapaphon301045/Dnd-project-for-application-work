using Dnd_project_for_application_work.DbContext;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;
using Dnd_project_for_application_work.Domain_Layer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dnd_project_for_application_work.Infrastructure_Layer.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly AppDbContext _context;

        public RaceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Race>> GetAllRaceAsync()
        {
            return await _context.Races.ToListAsync();
        }

    }
}
