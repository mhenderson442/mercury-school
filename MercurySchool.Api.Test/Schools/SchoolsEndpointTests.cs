using FluentAssertions;
using MercurySchool.Api.Constants;
using MercurySchool.Models.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;
using Xunit;

namespace MercurySchool.Api.Test.Schools;

public class SchoolsEndpointTests
{
    private static string SchoolId => "ceb83806-4fd3-4bc8-8301-7ff523729634";

    [Fact(DisplayName = "Schools GetAsync request should return an OK result")]
    public async Task GetSchoolsReturnsOk()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        // Act
        var response = await client.GetAsync(EndpointConstants.SchoolsPrefix);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact(DisplayName = "Schools GetAsync request with id parameter should return an OK result")]
    public async Task GetSchoolWithIdParamReturnsOk()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        // Act
        var response = await client.GetAsync($"{EndpointConstants.SchoolsPrefix}/{SchoolId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact(DisplayName = "Schools PostAsync request should return an OK result")]
    public async Task PostSchoolWithSchoolParamReturnsOk()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var school = GetSchool(Guid.NewGuid())!;
        school.Description = "New school insert by endpoint test";

        var serializedSchool = JsonSerializer.Serialize(school);

        using StringContent jsonContent = new(serializedSchool, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync($"{EndpointConstants.SchoolsPrefix}", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact(DisplayName = "Schools PutAsync request with school parameter should return an OK result")]
    public async Task PutSchoolWithSchoolParamReturnsOk()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var school = GetSchool(Guid.Parse(SchoolId))!;
        school.Description = "School has been updated by endpoint test";

        var serializedSchool = JsonSerializer.Serialize(school);

        using StringContent jsonContent = new(serializedSchool, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PutAsync($"{EndpointConstants.SchoolsPrefix}/{SchoolId}", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact(DisplayName = "Schools PatchAsync request with name should return an OK result")]
    public async Task PatchSchoolWithNameParamReturnsOk()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var school = GetSchool(Guid.Parse(SchoolId))!;
        school.Name = "Name patched by endpoint test";

        var serializedSchool = JsonSerializer.Serialize(school);

        using StringContent jsonContent = new(serializedSchool, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PatchAsync($"{EndpointConstants.SchoolsPrefix}/name/{SchoolId}", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact(DisplayName = "Schools PatchAsync request with description should return an OK result")]
    public async Task PatchSchoolWithDescriptionParamReturnsOk()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var school = GetSchool(Guid.Parse(SchoolId))!;
        school.Description = "Description patched by endpoint test";

        var serializedSchool = JsonSerializer.Serialize(school);

        using StringContent jsonContent = new(serializedSchool, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PatchAsync($"{EndpointConstants.SchoolsPrefix}/decription/{SchoolId}", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    private static School GetSchool(Guid id)
    {
        return new School
        {
            Description = "Test Description",
            Id = id,
            Name = $"Test GetSchool :: {Guid.NewGuid()}",
            CreateDate = DateTime.Now,
        };
    }
}