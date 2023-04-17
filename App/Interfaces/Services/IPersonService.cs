using Test_App.App.Domain;

namespace Test_App.App.Interfaces.Services;

public interface IPersonService
{
    IEnumerable<Person> GetAll(int pageIndex, int pageSize);
    int GetCount();
    Person? GetById(long id);
    Task CreateAsync(Person newPerson);
    Task UpdateAsync(long id, Person person);
    Task DeleteAsync(long id);
}