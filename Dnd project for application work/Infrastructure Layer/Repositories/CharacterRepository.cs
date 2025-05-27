using Dnd_project_for_application_work.DbContext;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;
using Dnd_project_for_application_work.Domain_Layer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dnd_project_for_application_work.Infrastructure_Layer.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _context;

        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Character>> GetAllCharacterAsync()
        {
            return await _context.Characters
                .Include(c => c.Alignment)
                .Include(c => c.Class)
                .Include(c => c.Race)
                .ToListAsync();
        }

        public async Task<Character?> GetByIdAsync(int id)
        {
            return await _context.Characters
                .Include(c => c.Alignment)
                .Include(c => c.Class)
                .Include(c => c.Race)
                .FirstOrDefaultAsync(c => c.CharacterId == id);
        }

        public async Task AddAsync(Character character)
        {
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }
    }
}
