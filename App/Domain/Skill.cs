namespace Test_App.App.Domain;

public record Skill
{
    public string Name { get; set; } = string.Empty;
    public byte Level { get; set; }
}