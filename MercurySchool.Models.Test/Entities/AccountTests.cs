using FluentAssertions;
using MercurySchool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercurySchool.Models.Test.Entities;

/// <summary>
/// Account tests
/// </summary>
public class AccountTests
{
    [Theory(DisplayName = "GetAccount entity should have required properties")]
    [InlineData(true)]
    [InlineData(false)]
    public void SchoolEntityHasRequiredProperties(bool hasNullDescription)
    {
        // Arrange
        var sut = GetAccount();

        if (hasNullDescription)
        {
            sut.Description = null;
        }

        // Act
        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<Account>();
    }

    [Fact(DisplayName = "GetAccount name should be updatable")]
    public void SchoolNameCanBeupdated()
    {
        // Arrange
        var sut = GetAccount();

        // Act
        sut.Name = "Upated name of account";

        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<Account>();
    }

    [Fact(DisplayName = "GetAccount description should be updatable")]
    public void SchoolDescriptionCanBeupdated()
    {
        // Arrange
        var sut = GetAccount();

        // Act
        sut.Description = "Upated description of account";

        // Assert
        sut.Should().NotBeNull().And.BeAssignableTo<Account>();
    }

    private static Account GetAccount() => new()
    {
        Id = Guid.NewGuid(),
        Name = "Name of account",
        Description = "Description of account",
        CreateDate = DateTime.UtcNow
    };
}