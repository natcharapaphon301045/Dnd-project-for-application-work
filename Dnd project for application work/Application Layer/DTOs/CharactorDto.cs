using System.ComponentModel.DataAnnotations;
using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Application_Layer.DTOs
{
    public class CharactorDto
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public string CharacterName { get; set; } = null!;

        public int AlignmentId { get; set; }
        public int ClassId { get; set; }
        public int RaceId { get; set; }

        public Alignment Alignment { get; set; } = null!;
        public Class Class { get; set; } = null!;
        public Race Race { get; set; } = null!;
    }
}
