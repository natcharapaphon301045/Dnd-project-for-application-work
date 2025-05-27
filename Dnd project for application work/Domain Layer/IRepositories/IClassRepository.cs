using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dnd_project_for_application_work.Domain_Layer.IRepositories
{
    public interface IClassRepository
    {
            Task<IEnumerable<Class>> GetAllClassAsync();
            
       
    }
}
