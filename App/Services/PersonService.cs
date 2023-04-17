using Test_App.App.Domain;
using Test_App.App.Interfaces.DataServices;
using Test_App.App.Interfaces.Services;

namespace Test_App.App.Services;

public class PersonService : IPersonService
{
    private readonly IPersonDataService _personDataService;

    public PersonService(IPersonDataService personDataService)
    {
        _personDataService = personDataService;
    }

    public int GetCount()
    {
        return _personDataService.GetCount();
    }

    public IEnumerable<Person> GetAll(int pageIndex, int pageSize)
    {
        return _personDataService.GetAll(pageIndex, pageSize);
    }

    public Person? GetById(long id)
    {
        return _personDataService.Get(id);
    }

    public async Task CreateAsync(Person newPerson)
    {
        await _personDataService.CreateAsync(newPerson);
    }

    public async Task UpdateAsync(long id, Person person)
    {
        person.Id = id;
        await _personDataService.UpdateAsync(person);
    }

    public async Task DeleteAsync(long id)
    {
        await _personDataService.DeleteAsync(id);
    }
}