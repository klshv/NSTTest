using System.ComponentModel.DataAnnotations;
using Test_App.App.Domain;

namespace Test_App.Data.Entities;

public record PersonEntity
{
    [Key]
    public long PersonId { get; set; }

    public string Name { get; set; } = String.Empty;

    public string DisplayName { get; set; } = String.Empty;

    public IEnumerable<SkillEntity> Skills { get; set; } = new List<SkillEntity>();

}