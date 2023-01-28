namespace MercurySchool.Api.Models;

public abstract class Account
{
    private string _accountId;

    public Account(string accountId) => AccountId = _accountId = accountId;

    required public string AccountId { get => _accountId; init => _accountId = value; }
}
