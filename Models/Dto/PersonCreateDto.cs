using Test_App.App.Domain;

namespace Test_App.Models.Dto;

public record PersonCreateDto
{
    public string Name { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public IEnumerable<SkillDto> Skills { get; set; } = new List<SkillDto>();
}