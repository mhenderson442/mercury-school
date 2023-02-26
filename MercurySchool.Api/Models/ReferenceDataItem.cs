using System.Diagnostics;

namespace MercurySchool.Api.Models;

/// <summary>
/// Reference Data Item
/// </summary>
/// <param name="Name">Name</param>
/// <param name="Type">Reference Type</param>
/// <returns></returns>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public record ReferenceDataItem(string Name, string Type)
{
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}