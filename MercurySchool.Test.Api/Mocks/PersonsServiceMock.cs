namespace MercurySchool.Test.Api.Mocks;

internal class PersonsServiceMock : IPersonsService
{
    public async Task<IList<Person>> GetPersonsAsync(string startsWithValue)
    {
        await Task.Yield();
        var persons = InitializePersonsMock();

        return persons;
    }

    public async Task<IList<Person>> GetPersonsAsync()
    {
        await Task.Yield();
        var persons = InitializePersonsMock();

        return persons;
    }

    private static Person InitializePersonMock()
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            MiddleName = "Q",
            LastName = "Public"
        };

        return person;
    }

    private static List<Person> InitializePersonsMock()
    {
        var person = InitializePersonMock();
        var persons = new List<Person>() { person };

        return persons;
    }

    public async Task<bool> PostPersonsAsync(Person person)
    {
        await Task.Yield();
        return true;
    }

    public async Task<bool> PutPersonsAsync(Person person)
    {
        await Task.Yield();
        return true;
    }

    public async Task<bool> PatchPersonsAsync(string id, Stream requestBody)
    {
        await Task.Yield();
        return true;
    }

    public async Task<bool> DeletePersonsAsync(string id)
    {
        await Task.Yield();
        return true;
    }
}