using MercurySchool.Models.Entities;

namespace MercurySchool.DataAccess.Repositories;

/// <summary>
/// The Account repository
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// The instance of an account by id
    /// </summary>
    /// <param name="id"><see cref="Guid"/> primary key</param>
    /// <returns>An instance of an <see cref="Account"/></returns>
    Task<Account> GetAccountAsync(Guid id);

    /// <summary>
    /// Add new account to the database
    /// </summary>
    /// <param name="account"><see cref="Account"/> to be added to database</param>
    /// <returns><see cref="bool"/> indicating success</returns>
    Task<bool> InsertAccountAsync(Account account);
}