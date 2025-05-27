using Dnd_project_for_application_work.Application_Layer.DTOs;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDto>> GetAllClassAsync();
        /*Task<ClassDto?> GetByIdAsync(int id);
        Task<ClassDto> CreateClassAsync(CreateClassDto dto);
        Task<bool> UpdateClassAsync(int id, UpdateClassDto dto);
        Task<bool> DeleteClassAsync(int id);*/
    }
}
