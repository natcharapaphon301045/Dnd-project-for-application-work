using Dnd_project_for_application_work.Application_Layer.DTOs;

namespace Dnd_project_for_application_work.Application_Layer.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDto>> GetAllClassAsync();
        Task<ClassDto?> GetClassByIdAsync(int id);
        Task<ClassDto> CreateClassAsync(ClassDto classDto);
        Task<bool> UpdateClassAsync(int id, ClassDto classDto);
        Task<bool> DeleteClassAsync(int id);
    }
}
