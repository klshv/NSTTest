using Test_App.Data.Entities;

namespace Test_App.App.Domain;

public record Person
{
    public Person(string name, string displayName, IEnumerable<Skill>? skills = null)
    {
        Name = name;
        DisplayName = displayName;
        Skills = skills ?? new List<Skill>();
    }

    public long Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public IEnumerable<Skill> Skills { get; set; }
}