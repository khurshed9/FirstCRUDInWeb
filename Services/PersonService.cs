using Dapper;
using FirstCrudInWeb.Models;
using Npgsql;

namespace FirstCrudInWeb.Services;

public class PersonService : IPersonService
{
    public IEnumerable<Person> GetAllPersons()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<Person>(SqlCommands.GetAllPersons);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Person? GetPersonById(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.GetPersonById))
            {
                connection.Open();
                return connection.QuerySingleOrDefault<Person>(SqlCommands.GetPersonById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool CreatePerson(Person person)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.CreatePerson))
            {
                connection.Open();
                return connection.Execute(SqlCommands.CreatePerson, person) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdatePerson(Person person)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.UpdatePerson))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdatePerson, person) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeletePerson(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.DeletePerson))
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeletePerson, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommands
{
    public const string ConnectionString = "Server=localhost;Port=5432;Database=webapi_db;Username=postgres;Password=Galchaew05;";
    
    public static string GetAllPersons = "SELECT * FROM persons;";
    
    public static string GetPersonById = "SELECT * FROM persons WHERE id = @id;";
    
    public static string CreatePerson = "INSERT INTO persons (name, age) VALUES (@name, @age);";
    
    public static string UpdatePerson = "UPDATE persons SET name = @name, age = @age WHERE id = @id;";
    
    public static string DeletePerson = "DELETE FROM persons WHERE id = @id;";
}