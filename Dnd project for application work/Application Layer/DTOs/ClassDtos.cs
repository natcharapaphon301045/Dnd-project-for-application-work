using System.ComponentModel.DataAnnotations;
using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Application_Layer.DTOs
{
    public class ClassDtos
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public string ClassName { get; set; } = null!;

        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
