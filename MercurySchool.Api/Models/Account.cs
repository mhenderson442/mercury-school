using System.Diagnostics;

namespace MercurySchool.Api.Models;

/// <summary>
/// Account record
/// </summary>
/// <param name="AccountId">Accepts a string intended to be an Id form data store</param>
/// <returns>Account</returns>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract record Account(string AccountId)
{
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}