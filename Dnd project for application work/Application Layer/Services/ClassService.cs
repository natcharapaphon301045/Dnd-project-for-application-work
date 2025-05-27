using Dnd_project_for_application_work.Application_Layer.DTOs;
using Dnd_project_for_application_work.Domain_Layer;
using Dnd_project_for_application_work.Domain_Layer.IRepositories;

namespace Dnd_project_for_application_work.Application_Layer.Services
{
    public class ClassService
    {
        private readonly IClassRepository _ClassRepository;

        public ClassService(IClassRepository ClassRepository)
        {
            _ClassRepository = ClassRepository;
        }

        public async Task<IEnumerable<ClassDto>> GetAllClassAsync()
        {
            var Classes = await _ClassRepository.GetAllClassAsync();

            return Classes.Select(c => new ClassDto
            {
                ClassId = c.ClassId,
                ClassName = c.ClassName
            });
        }
    }
}
