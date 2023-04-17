using System.ComponentModel.DataAnnotations;

namespace Test_App.Data.Entities;

public record SkillEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public byte Level { get; set; } 
}