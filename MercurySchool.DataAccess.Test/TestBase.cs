using MercurySchool.DataAccess.Connections;
using MercurySchool.DataAccess.Repositories;
using MercurySchool.DataAccess.Test.Connections;
using MercurySchool.Models.Entities;
using MercurySchool.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MercurySchool.DataAccess.Test;

/// <summary>
/// Test base class
/// </summary>
public class TestBase
{
    /// <summary>
    ///  Mocked instance of <see cref="Account"/>
    /// </summary>
    /// <returns></returns>
    internal static Account GetAccount() => new()
    {
        Id = Guid.NewGuid(),
        Description = "Description of account",
        Name = "Name of account",
        CreateDate = DateTime.UtcNow
    };

    /// <summary>
    /// Mocked instance of <see cref="Student"/>
    /// </summary>
    /// <returns></returns>
    internal static Student GetStudent() => new()
    {
        Person = GetPerson(),
        StudentAcademicStatus = GetStudentAcademicStatus()
    };

    /// <summary>
    /// Mocked instance of <see cref="StudentAcademicStatus"/>
    /// </summary>
    internal static StudentAcademicStatus GetStudentAcademicStatus() => new()
    {
        Description = "Undertmined",
        Id = 5,
        Name = "Undetermined"
    };

    /// <summary>
    /// Mocked instance of <see cref="IAccountRepository"/>
    /// </summary>
    /// <returns><see cref="IAccountRepository"/></returns>
    internal static async Task<IAccountRepository> GetAccountRepositoryAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        IDatabaseConnections sqlConnection = new SqlDatabaseConnection(options);

        return new AccountRepository(sqlConnection);
    }

    /// <summary>
    /// Mocked options for depency injection.
    /// </summary>
    /// <returns><see cref="IOptions{T}"/></returns>
    internal static async Task<IOptions<AppSettings>> GetAppSettingsOptionsAsync()
    {
        var configuration = new ConfigurationBuilder()
        .AddUserSecrets<SqlDatabaseConnectionTests>()
        .Build();

        var appSettings = new AppSettings
        {
            SqlConnectionSettings = new SqlConnectionSettings
            {
                DataSource = configuration["AppSettings:SqlConnectionSettings:DataSource"]!,
                InitialCatalog = configuration["AppSettings:SqlConnectionSettings:InitialCatalog"]!,
                Password = configuration["AppSettings:SqlConnectionSettings:Password"]!,
                TrustServerCertificate = Convert.ToBoolean(configuration["AppSettings:SqlConnectionSettings:TrustServerCertificate"])!,
                UserID = configuration["AppSettings:SqlConnectionSettings:UserID"]!
            }
        };

        IOptions<AppSettings> options = (IOptions<AppSettings>)Options.Create(appSettings);

        return await Task.FromResult(options);
    }

    /// <summary>
    /// Mocked person object
    /// </summary>
    /// <returns><see cref="Person"/></returns>
    internal static Person GetPerson() => new()
    {
        CreateDate = DateTime.UtcNow,
        Description = "Description of school",
        FirstName = "John",
        Id = Guid.NewGuid(),
        LastName = "Public",
        MiddleName = "Q",
        Name = "Name of person"
    };

    /// <summary>
    /// Mocked instance of <see cref="IPersonRepository"/>
    /// </summary>
    /// <returns><see cref="IPersonRepository"/></returns>
    internal static async Task<IPersonRepository> GetPersonRepositoryAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        IDatabaseConnections sqlConnection = new SqlDatabaseConnection(options);

        return new PersonRepository(sqlConnection);
    }

    /// <summary>
    /// Mocked instance of <see cref="ISchoolRepository"/>
    /// </summary>
    /// <returns><see cref="ISchoolRepository"/></returns>
    internal static async Task<ISchoolRepository> GetSchoolRepositoryAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        IDatabaseConnections sqlConnection = new SqlDatabaseConnection(options);

        return new SchoolRepository(sqlConnection);
    }

    /// <summary>
    /// Mocked instance of <see cref="IStudentAcademicStatusRespository"/>
    /// </summary>
    /// <returns><see cref="IStudentAcademicStatusRespository"/></returns>
    internal static async Task<IStudentAcademicStatusRespository> GetStudentAcademicStatusRepositoryAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        IDatabaseConnections sqlConnection = new SqlDatabaseConnection(options);

        return new StudentAcademicStatusRespository(sqlConnection);
    }

    /// <summary>
    /// Mocked instance of <see cref="IStudentRepository"/>
    /// </summary>
    /// <returns><see cref="IStudentRepository"/></returns>
    internal static async Task<IStudentRepository> GetStudentRepositoryAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        IDatabaseConnections sqlConnection = new SqlDatabaseConnection(options);

        return new StudentRepository(sqlConnection);
    }

    /// <summary>
    /// Mocked instance of <see cref="SqlDatabaseConnection"/>
    /// </summary>
    /// <returns><see cref="SqlDatabaseConnection"/></returns>
    internal static async Task<SqlDatabaseConnection> InitializeSqlDatabaseConnectionAsync()
    {
        var options = await GetAppSettingsOptionsAsync();
        return new SqlDatabaseConnection(options);
    }
}