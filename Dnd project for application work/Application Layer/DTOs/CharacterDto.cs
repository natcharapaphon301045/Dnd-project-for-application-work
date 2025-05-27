public class CharacterDto
{
    public int CharacterId { get; set; }
    public string CharacterName { get; set; } = null!;

    public string AlignmentName { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public string RaceName { get; set; } = null!;
}
public class CreateCharacterDto
{
    public int CharacterId { get; set; }
    public string CharacterName { get; set; } = string.Empty;
    public int AlignmentId { get; set; }
    public int ClassId { get; set; }
    public int RaceId { get; set; }
    public string AlignmentName { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string RaceName { get; set; } = string.Empty;
}

