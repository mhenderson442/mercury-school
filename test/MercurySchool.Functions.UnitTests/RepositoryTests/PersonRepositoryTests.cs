using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using MercurySchool.Functions.Models;
using MercurySchool.Functions.Repositories;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace MercurySchool.Functions.UnitTests.RepositoryTests
{
    public class PersonRepositoryTests
    {
        private PersonRepository _personRepository;

        public PersonRepositoryTests()
        {

            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets("c376b48b-8bd2-4d5d-a693-803ebafc9275")
                .Build();

            PersonRepository = new PersonRepository(configuration);
        }

        public PersonRepository PersonRepository
        {
            get => _personRepository;
            set => _personRepository = value;
        }

        [Theory(DisplayName = "GetPersons Should Return List")]
        [InlineData(null, null)]
        [InlineData(0, 25)]
        public async Task GetPersonsShouldReturnListName(int? offset, int? fetch)
        {
            // Arrange
            var sqlPagination = new SqlPagination(offset, fetch);

            // Act
            var sut = await PersonRepository.GetPersons(sqlPagination);

            // Assert
            sut.Should()
                .NotBeEmpty("because because the method should not return an empty list")
                .And.ContainItemsAssignableTo<Person>("because the list returned should be a list of type person")
                .And.HaveCount(x => x > 1, "because the GetPerson method should not return 1 rows");
        }

        [Fact(DisplayName = "Get Persons Should Return Person")]
        public async Task GetPersonsShouldReturnPerson()
        {
            // Arrange
            var id = 1;

            // Act
            var sut = await PersonRepository.GetPersonsAsync(id);

            // Assert
            sut.Should()
                .NotBeNull("because the id passed should return a person")
                .And.BeOfType<Person>("becuase the object return should be an instance of a person");
        }

        [Fact(DisplayName = "Insert Person Should Return Person")]
        public async Task InsertPersonsReturnsPerson()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "Unit",
                MiddleName = "B",
                LastName = "Test"
            };

            // Act
            var sut = await PersonRepository.InsertPersonsAsync(person);

            // Assert
            sut.Should()
                .NotBeNull("because an instance of person should be returned")
                .And.BeOfType<Person>("because an instance of person should be returned");

            sut.Id.Should()
                .BeGreaterThan(0, "because returned instance of Person should have newly created Id");
        }

        [Fact(DisplayName = "Insert Persons Should Return List of Type Persons")]
        public async Task InsertPersonsReturnList()
        {
            // Arrange
            var person0 = new Person
            {
                FirstName = "Unit",
                MiddleName = "C",
                LastName = "Test"
            };

            var person1 = new Person
            {
                FirstName = "Unit",
                MiddleName = "D",
                LastName = "Test"
            };

            var persons = new Queue<Person>();
            persons.Enqueue(person0);
            persons.Enqueue(person1);

            // Act
            var sut = await PersonRepository.InsertPersonsAsync(persons);

            // Assert
            sut.Should()
                .NotBeEmpty("because because the method should not return an empty list")
                .And.ContainItemsAssignableTo<Person>("because the list returned should be a list of type person")
                .And.HaveCount(x => x > 1, "because the GetPerson method should not return 1 rows");
        }

        [Fact]
        public async Task UpdatePersonsReturnsList()
        {
            // Arrange
            var person0LastName = Guid.NewGuid().ToString();
            var person1LastName = Guid.NewGuid().ToString();

            var person0 = new Person
            {
                Id = 27,
                FirstName = "Unit",
                MiddleName = "C",
                LastName = person0LastName
            };

            var person1 = new Person
            {
                Id = 28,
                FirstName = "Unit",
                MiddleName = "D",
                LastName = person1LastName
            };

            var persons = new Queue<Person>();
            persons.Enqueue(person0);
            persons.Enqueue(person1);

            // Act
            var sut = await PersonRepository.UpdatePersonsAsync(persons);

            // Assert
            sut.Should()
                .NotBeEmpty("because because the method should not return an empty list")
                .And.ContainItemsAssignableTo<Person>("because the list returned should be a list of type person")
                .And.HaveCount(x => x > 1, "because the GetPerson method should not return 1 rows.");
        }

        [Fact(DisplayName = "Update Person Should Return Person")]
        public async Task UpdatePersonsReturnsPerson()
        {
            // Arrange
            var lastName = Guid.NewGuid().ToString();

            var person = new Person
            {
                Id = 3,
                FirstName = "Unit",
                MiddleName = "B",
                LastName = lastName
            };

            // Act
            var sut = await PersonRepository.UpdatePersonsAsync(person);

            // Assert
            sut.Should()
                .NotBeNull("because an instance of person should be returned")
                .And.BeOfType<Person>("because an instance of person should be returned");

            sut.Id.Should()
                .Be(3, "because returned instance of person should have an Id macthing what was submitted");

            sut.LastName.Should()
                .Be(lastName, $"because LastName does not equal { lastName }");
        }

        [Fact(DisplayName = "DeletePerson should return the id that has been deleted")]
        public async Task DeletePersonReturnsDeletedId()
        {
            // Arrangev
            var person = new Person
            {
                FirstName = "Delete",
                MiddleName = "A",
                LastName = "PersonTest"
            };

            var insertedPerson = await PersonRepository.InsertPersonsAsync(person);
            var id = (int)insertedPerson.Id;

            // Act
            var sut = await PersonRepository.DeletePersonsAsync(id);

            // Asert
            sut.Should().Be(id, "because DeletePersons should return the id of the deleted person");
        }
    }
}