﻿namespace MercurySchool.Api.Repositories;

/// <summary>
/// Reference Data Repository
/// </summary>
public interface IReferenceDataRepository
{
    /// <summary>
    /// Get a list of reference data items by type.
    /// </summary>
    /// <param name="academicStatus">ReferenceContainer data type</param>
    /// <returns>List of type string</returns>
    Task<List<string>> GetReferenceDataAsync(string academicStatus);
}
