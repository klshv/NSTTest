using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Test_App.App.Domain;
using Test_App.App.Interfaces.DataServices;
using Test_App.Data.Entities;

namespace Test_App.Data.Services;

public class PersonDataService : IPersonDataService
{
    private readonly TestAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public PersonDataService(TestAppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public int GetCount()
    {
        return _dbContext.Persons.Count();
    }

    public IEnumerable<Person> GetAll(int pageIndex, int pageSize)
    {
        return GetJoinedPersonAndSkills()
            .Select(x => _mapper.Map<Person>(x))
            .Skip(pageIndex * pageSize)
            .Take(pageSize);
    }

    public Person? Get(long id)
    {
        return GetEntityById(id)
            .Select(x => _mapper.Map<Person>(x))
            .FirstOrDefault();
    }

    public async Task<Person> CreateAsync(Person newPerson)
    {
        var newPersonEntity = _mapper.Map<PersonEntity>(newPerson);
        var createdPersonEntity = await _dbContext.Persons.AddAsync(newPersonEntity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<Person>(createdPersonEntity.Entity);
    }

    public async Task UpdateAsync(Person updatedPerson)
    {
        var personToUpdate = GetEntityById(updatedPerson.Id).First();
        _dbContext.Entry(personToUpdate).CurrentValues.SetValues(updatedPerson);
        await _dbContext.SaveChangesAsync();
    }


    public async Task DeleteAsync(long personId)
    {
        _dbContext.ChangeTracker.CascadeDeleteTiming = CascadeTiming.Immediate;

        var personEntityBeingDeleted = GetEntityById(personId).First();
        _dbContext.Persons.Remove(personEntityBeingDeleted);
        _dbContext.ChangeTracker.CascadeChanges();
        await _dbContext.SaveChangesAsync();
    }

    private IIncludableQueryable<PersonEntity, IEnumerable<SkillEntity>> GetJoinedPersonAndSkills() =>
        _dbContext.Persons
            .Include(p => p.Skills);

    private IEnumerable<PersonEntity> GetEntityById(long id)
    {
        return GetJoinedPersonAndSkills()
            .Where(s => s.PersonId == id);
    }
}

