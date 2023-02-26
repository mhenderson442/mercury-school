namespace MercurySchool.Api.Tests.ModelTests
{
    public class PersonTests
    {
        [Fact]
        public void PersonObjectImplementsInterface()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            var accountId = Guid.NewGuid().ToString();
            var firstName = "John";
            var lastName = "Public";

            // Act
            var sut = new Person(accountId){ Id = id, FirstName = firstName, MiddleName = "Q", LastName = lastName};
  
            // Assert
            sut.Should().BeAssignableTo<Person>();
        }
    }
}