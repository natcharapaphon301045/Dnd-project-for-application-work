using Dnd_project_for_application_work.Application_Layer.DTOs;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface IAlignmentService
    {
        Task<IEnumerable<AlignmentDto>> GetAllAlignmentAsync();
        Task<AlignmentDto?> GetAlignmentByIdAsync(int id);
        Task<AlignmentDto> CreateAlignmentAsync(AlignmentDto alignmentDto);
        Task<bool> UpdateAlignmentAsync(int id, AlignmentDto alignmentDto);
        Task<bool> DeleteAlignmentAsync(int id);
    }
}
