using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Domain_Layer
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public string CharacterName { get; set; } = null!;

        // Foreign Keys
        public int AlignmentId { get; set; }
        public int ClassId { get; set; }
        public int RaceId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(AlignmentId))]
        public Alignment Alignment { get; set; } = null!;

        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; } = null!;

        [ForeignKey(nameof(RaceId))]
        public Race Race { get; set; } = null!;
    }

}
