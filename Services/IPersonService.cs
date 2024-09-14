using FirstCrudInWeb.Models;

namespace FirstCrudInWeb.Services;

public interface IPersonService
{
    IEnumerable<Person> GetAllPersons();
    
    Person? GetPersonById(int id);
    
    bool CreatePerson(Person person);
    
    bool UpdatePerson(Person person);   
    
    bool DeletePerson(int id);
}