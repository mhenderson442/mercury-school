namespace MercurySchool.Api.Models;

/// <summary>
/// Account
/// </summary>
public abstract class Account : IAccount
{
    private string _accountId;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="accountId">Account Id</param>
    public Account(string accountId) => AccountId = _accountId = accountId;

    /// <summary>
    /// Account Id property
    /// </summary>
    /// <value></value>
    required public string AccountId { get => _accountId; init => _accountId = value; }
}
