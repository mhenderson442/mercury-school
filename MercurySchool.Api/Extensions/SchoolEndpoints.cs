namespace MercurySchool.Api.Extensions;

/// <summary>
/// School enpoints
/// </summary>
public static class SchoolEndpoints
{
    /// <summary>
    /// Add school endpoints
    /// </summary>
    /// <param name="routes">An instance of <see cref="IEndpointRouteBuilder"/></param>
    public static void AddSchoolEndpoints(this IEndpointRouteBuilder routes)
    {
        var schools = routes.MapGroup(EndpointConstants.SchoolsPrefix);

        schools.MapGet("/", GetSchoolsAsync).WithOpenApi(o => new(o) { Summary = "Get all schools" });
        schools.MapGet("/{id}", GetSchoolAsync).WithOpenApi(o => new(o) { Summary = "Get a specific school by Id" });

        schools.MapPut("/{id}", UpdateSchool).WithOpenApi(o => new(o) { Summary = "Update an existing School" });
        schools.MapPost("/", CreateSchool).WithOpenApi(o => new(o) { Summary = "Insert new School" });

        schools.MapPatch("/name/{id}", PatchSchoolName).WithOpenApi(o => new(o) { Summary = "Patch School name" });
        schools.MapPatch("/decription/{id}", PatchSchoolDescription).WithOpenApi(o => new(o) { Summary = "Patch School description" });
    }

    public static async Task<Created<School>> CreateSchool(School school, [FromServices] ISchoolRepository schoolRepository)
    {
        _ = await schoolRepository.InsertSchoolAsync(school);

        var uri = $"{EndpointConstants.SchoolsPrefix}/{school.Id}";

        return TypedResults.Created(uri, school);
    }

    public static async Task<Results<NoContent, NotFound>> UpdateSchool(string id, School school, [FromServices] ISchoolRepository schoolRepository)
    {
        school.Id = Guid.Parse(id);

        return await schoolRepository.UpdateSchoolAsync(school)
            ? TypedResults.NoContent()
            : TypedResults.NotFound();
    }

    public static async Task<Results<NoContent, NotFound>> PatchSchoolName(string id, School school, [FromServices] ISchoolRepository schoolRepository)
    {
        school.Id = Guid.Parse(id);

        return await schoolRepository.UpdateSchoolNameAsync(school.Id, school.Name)
            ? TypedResults.NoContent()
            : TypedResults.NotFound();
    }

    public static async Task<Results<NoContent, NotFound>> PatchSchoolDescription(string id, School school, [FromServices] ISchoolRepository schoolRepository)
    {
        school.Id = Guid.Parse(id);

        return await schoolRepository.UpdateSchoolDescriptionAsync(school.Id, school.Description!)
            ? TypedResults.NoContent()
            : TypedResults.NotFound();
    }

    public static async Task<Ok<IEnumerable<School>>> GetSchoolsAsync([FromServices] ISchoolRepository schoolRepository) =>
        TypedResults.Ok(await schoolRepository.GetSchoolsAsync());

    public static async Task<Results<Ok<School>, NotFound>> GetSchoolAsync(string id, [FromServices] ISchoolRepository schoolRepository) =>
        await schoolRepository.GetSchoolAsync(Guid.Parse(id))
        is School school
            ? TypedResults.Ok(school)
            : TypedResults.NotFound();
}