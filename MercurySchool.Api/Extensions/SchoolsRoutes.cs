namespace MercurySchool.Api.Extensions;

/// <summary>
/// School Routes
/// </summary>
public static class SchoolsRoutes
{
    /// <summary>
    /// Map school endpoints.
    /// </summary>
    /// <param name="routes"><see cref="IEndpointRouteBuilder"/>routes</param>
    public static void MapSchools(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/schools", async ([FromServices] ISchoolsService schoolsService) =>
            await schoolsService.GetSchoolsAsync()
                is IList<School> schools
                    ? Results.Ok(schools)
                    : Results.NotFound());

        routes.MapGet("/api/schools/{id}", async (string id, [FromServices] ISchoolsService schoolsService) =>
            await schoolsService.GetSchoolAsync(id)
                is School school
                    ? Results.Ok(school)
                    : Results.NotFound());

        routes.MapPost("/api/schools", async (School school, [FromServices] ISchoolsService schoolsService) =>
            await schoolsService.PostSchoolAsync(school)
                is true
                    ? Results.Created()
                    : Results.BadRequest());

        routes.MapPatch("/api/schools/{id}", async (string id, HttpRequest request, [FromServices] ISchoolsService schoolsService) =>
            await schoolsService.PatchSchoolAsync(id, request.Body)
                is true
                    ? Results.NoContent()
                    : Results.BadRequest());
    }
}