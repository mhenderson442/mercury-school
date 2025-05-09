﻿namespace MercurySchool.DataAccess.Repositories;

/// <summary>
/// The school repository
/// </summary>
public interface ISchoolRepository
{
    /// <summary>
    /// Get an instance of a <see cref="School"/> filtered on the id
    /// </summary>
    /// <param name="id">An inance of a <see cref="Guid"/> representing the database primary key.</param>
    /// <returns>An instance of <see cref="School"/></returns>
    Task<School> GetSchoolAsync(Guid id);

    /// <summary>
    /// Get a list of all schools.
    /// </summary>
    /// <returns>An instance of <see cref="IEnumerable{T}>"/> of type School.</returns>
    Task<IEnumerable<School>> GetSchoolsAsync();

    /// <summary>
    /// Insert a new school in the database.
    /// </summary>
    /// <param name="school">Instance of a <see cref="School"/> to be inserted into the database.</param>
    /// <returns>A <see cref="bool"/> indicating sucess of the insert.</returns>
    Task<bool> InsertSchoolAsync(School school);

    /// <summary>
    /// Update school
    /// </summary>
    /// <param name="school">Instance of a <see cref="School"/> to be update the database.</param>
    /// <returns>A <see cref="bool"/> indicating sucess of the update.</returns>
    Task<bool> UpdateSchoolAsync(School school);

    /// <summary>
    /// Update school description
    /// </summary>
    /// <param name="id">An inance of a <see cref="Guid"/> representing the database primary key.</param>
    /// <param name="description">Udated school description.</param>
    /// <returns>A <see cref="bool"/> indicating sucess of the update.</returns>
    Task<bool> UpdateSchoolDescriptionAsync(Guid id, string description);

    /// <summary>
    /// Update school name
    /// </summary>
    /// <param name="id">An inance of a <see cref="Guid"/> representing the database primary key.</param>
    /// <param name="name">Updated school name</param>
    /// <returns>A <see cref="bool"/> indicating sucess of the update.</returns>
    Task<bool> UpdateSchoolNameAsync(Guid id, string name);
}