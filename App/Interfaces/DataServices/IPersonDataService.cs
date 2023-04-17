using Test_App.App.Domain;

namespace Test_App.App.Interfaces.DataServices;

public interface IPersonDataService
{
    IEnumerable<Person> GetAll(int pageIndex, int pageSize);
    int GetCount();
    Person? Get(long id);
    Task<Person> CreateAsync(Person newPerson);
    Task UpdateAsync(Person updatedPerson);
    Task DeleteAsync(long id);
}