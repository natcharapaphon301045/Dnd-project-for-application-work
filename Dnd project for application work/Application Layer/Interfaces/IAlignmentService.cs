using Dnd_project_for_application_work.Application_Layer.DTOs;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface IAlignmentService
    {
        Task<IEnumerable<AlignmentDto>> GetAllAlignmentAsync();
        /*Task<AlignmentDto?> GetByIdAsync(int id);
        Task<AlignmentDto> CreateAlignmentAsync(CreateAlignmentDto dto);
        Task<bool> UpdateAlignmentAsync(int id, UpdateAlignmentDto dto);
        Task<bool> DeleteAlignmentAsync(int id);*/
    }
}
