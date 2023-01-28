namespace MercurySchool.Api.Factories;

public interface IDataAccessFactory
{
    Task<Container> GetPersonContainerAsync();
    Task<Container> GetReferenceDataContainerAsync();
}
