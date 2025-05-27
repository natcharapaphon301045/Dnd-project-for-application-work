using System.ComponentModel.DataAnnotations;
using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Application_Layer.DTOs
{
    public class RaceDto
    {
        [Key]
        public int RaceId { get; set; }
        [Required]
        public required string RaceName { get; set; }

        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
