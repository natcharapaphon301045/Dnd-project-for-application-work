using Dnd_project_for_application_work.Infrastructure_Layer.Persistence_DbContext;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;
using Dnd_project_for_application_work.Domain_Layer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dnd_project_for_application_work.Infrastructure_Layer.Repositories
{
    public class AlignmentRepository : IAlignmentRepository
    {
        private readonly AppDbContext _context;

        public AlignmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Alignment>> GetAllAlignmentAsync()
        {
            return await _context.Alignments.ToListAsync();
        }
        public async Task<Alignment?> GetAlignmentByIdAsync(int id)
        {
            return await _context.Alignments.FirstOrDefaultAsync(c => c.AlignmentId == id);
        }


    }
}
