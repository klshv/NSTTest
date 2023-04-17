namespace Test_App.Models.Dto;

public record SkillDto
{
    public string Name { get; set; } = string.Empty;
    public byte Level { get; set; }
}