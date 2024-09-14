using FirstCrudInWeb.Models;
using FirstCrudInWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstCrudInWeb.Controllers;


[Route("Category")]
[ApiController]

public class PersonController : ControllerBase
{
    private readonly IPersonService _personService = new PersonService();

    [HttpGet]
    public IEnumerable<Person> GetAllPersons()
    {
        return _personService.GetAllPersons();
    }

    [HttpGet("{id}")]
    public Person? GetPersonById(int id)
    {
        return _personService.GetPersonById(id);
    }

    [HttpPost]
    public bool CreatePerson(Person person)
    {
        return _personService.CreatePerson(person);
    }

    [HttpPut]
    public bool UpdatePerson(Person person)
    {
        return _personService.UpdatePerson(person);
    }
    
    [HttpDelete]
    public bool DeletePerson(int id)
    {
        return _personService.DeletePerson(id);
    }
}