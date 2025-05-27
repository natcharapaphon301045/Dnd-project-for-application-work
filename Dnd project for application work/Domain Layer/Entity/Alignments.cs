using System.ComponentModel.DataAnnotations;

namespace Dnd_project_for_application_work.Domain_Layer
{
    public class Alignment
    {
        [Key]
        public int AlignmentId { get; set; }

        [Required]
        public string AlignmentName { get; set; } = null!;

        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
