namespace MercurySchool.Api.Factories;

/// <summary>
/// Data access factory
/// </summary>
public interface IDataAccessFactory
{
    /// <summary>
    /// Get Cosmos Db person container
    /// </summary>
    /// <returns>Instance of <see cref="Container"></see></returns>
    Task<Container> GetPersonContainerAsync();

    /// <summary>
    /// Get Cosmos Db reference data container
    /// </summary>
    /// <returns>Instance of <see cref="Container"></see></returns>
    Task<Container> GetReferenceDataContainerAsync();
}
