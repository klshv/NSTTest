using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Test_App.App.Domain;
using Test_App.App.Interfaces.Services;
using Test_App.Models.Dto;


namespace Test_App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IPersonService _personService;

    public PersonController(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

   
    [HttpGet(nameof(List))]
    public PersonListDto List([BindRequired] int pageIndex = 0, [BindRequired] int pageSize = 10)
    {
        return new PersonListDto
        {
            Count = _personService.GetCount(),
            Persons = _personService.GetAll(pageIndex, pageSize)
                .Select(x => _mapper.Map<PersonDto>(x))
        };
    }

    // GET api/<PersonController>/5
    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(long id)
    {
        var person = _personService.GetById(id);

        if (person == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PersonDto>(person));
    }

    // POST api/<PersonController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<PersonDto>> PostAsync([FromBody] PersonCreateDto value)
    {
        var newPerson = _mapper.Map<Person>(value);
        await _personService.CreateAsync(newPerson);
        return CreatedAtAction(nameof(Get), new { id = newPerson.Id }, _mapper.Map<PersonDto>(newPerson));
    }

    // PUT api/<PersonController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PutAsync(long id, [FromBody] PersonCreateDto value)
    {
        var person = _mapper.Map<Person>(value);
        await _personService.UpdateAsync(id, person);
        return NoContent();
    }

    // DELETE api/<PersonController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(long id)
    {
        await _personService.DeleteAsync(id);
        return NoContent();
    }
}