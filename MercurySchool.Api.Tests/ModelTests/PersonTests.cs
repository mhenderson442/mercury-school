namespace MercurySchool.Api.Tests.ModelTests
{
    public class PersonTests
    {
        [Fact]
        public void PersonObjectImplementInterface()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            var accountId = Guid.NewGuid().ToString();
            var firstName = "John";
            var lastName = "Public";

            // Act
            var sut = new Person(id,accountId,firstName,lastName);
            sut.MiddleName = "Q";

            // Assert
            sut.Should().BeAssignableTo<Person>();
        }
    }
}