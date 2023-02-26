using System.Diagnostics;

namespace MercurySchool.Api.Models;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
internal record AppSettings(string CosmosConnectionString)
{
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}