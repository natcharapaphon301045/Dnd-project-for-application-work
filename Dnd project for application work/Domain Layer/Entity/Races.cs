using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Domain_Layer
{
    public class Race
    {

        [Key]
        public int RaceId { get; set; }
        [Required]
        public required string RaceName { get; set; }

        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
