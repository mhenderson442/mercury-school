using System.Net;

namespace MercurySchool.Api.Extensions;

/// <summary>
/// Person Routes
/// </summary>
public static class PersonsRoutes
{
    /// <summary>
    /// Map person endpoints
    /// </summary>
    /// <param name="routes"><see cref="IEndpointRouteBuilder"/>routes</param>
    public static void MapPersons(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/persons", async ([FromQuery(Name = "startsWithValue")] string? startsWithValue, [FromServices] IPersonsService personsService) =>
        await personsService.GetPersonsAsync(startsWithValue)
            is IList<Person> persons
                ? Results.Ok(persons)
                : Results.NotFound());

        routes.MapGet("/api/persons/{id}", async (string id, [FromServices] IPersonsService personsService) =>
        await personsService.GetPersonsAsync(Guid.Parse(id))
            is Person person
                ? Results.Ok(person)
                : Results.NotFound());

        routes.MapPost("/api/persons", async (Person person, [FromServices] IPersonsService personsService) =>
        await personsService.PostPersonsAsync(person)
            is true
                ? Results.Created()
                : Results.BadRequest());

        routes.MapPut("/api/persons", async (Person person, [FromServices] IPersonsService personsService) =>
        await personsService.PutPersonsAsync(person)
            is true
                ? Results.NoContent()
                : Results.BadRequest());

        routes.MapPatch("/api/persons/{id}", async (string id, HttpRequest request, [FromServices] IPersonsService personsService) =>
        await personsService.PatchPersonsAsync(id, request.Body)
            is true
                ? Results.NoContent()
                : Results.BadRequest());

        routes.MapDelete("/api/persons/{id}", async (string id, [FromServices] IPersonsService personsService) =>
            await personsService.DeletePersonsAsync(id)
                is true
                    ? Results.NoContent()
                    : Results.BadRequest());
    }
}