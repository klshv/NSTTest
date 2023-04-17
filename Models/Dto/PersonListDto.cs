namespace Test_App.Models.Dto;

public record PersonListDto
{
    public int Count { get; set; } = 0;
    public IEnumerable<PersonDto> Persons { get; set; } = new List<PersonDto>();
}