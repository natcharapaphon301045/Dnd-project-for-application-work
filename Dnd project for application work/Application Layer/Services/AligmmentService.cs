using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;
using Dnd_project_for_application_work.Infrastructure_Layer.Repositories;

namespace Dnd_project_for_application_work.Application_Layer.Services
{
    public class AlignmentService
    {
        private readonly IAlignmentRepository _AlignmentRepository;

        public AlignmentService(IAlignmentRepository AlignmentRepository)
        {
            _AlignmentRepository = AlignmentRepository;
        }

        public async Task<IEnumerable<AlignmentDto>> GetAllAlignmentAsync()
        {
            var Alignments = await _AlignmentRepository.GetAllAlignmentAsync();

            return Alignments.Select(c => new AlignmentDto
            {
                AlignmentId = c.AlignmentId,
                AlignmentName = c.AlignmentName
            });
        }
        public async Task<AlignmentDto?> GetAlignmentByIdAsync(int id)
        {
            var c = await _AlignmentRepository.GetAlignmentByIdAsync(id);
            if (c == null) return null;

            return new AlignmentDto
            {
                AlignmentId = c.AlignmentId,
                AlignmentName = c.AlignmentName
            };
        }
    }
}
