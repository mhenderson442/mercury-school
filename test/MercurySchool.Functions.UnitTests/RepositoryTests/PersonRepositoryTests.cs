using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using MercurySchool.Functions.Models;
using MercurySchool.Functions.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace MercurySchool.Functions.UnitTests.RepositoryTests
{
    public class PersonRepositoryTests
    {
        private PersonRepository _personRepository;

        public PersonRepositoryTests(){
            
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

        [Theory(DisplayName = "GetPerson method without parmater returns list.")]
        [InlineData(null, null)]
        [InlineData(0, 25)]
        public async Task TestGetPersonShouldReturnListame(int? offset, int? fetch)
        {
            // Arrange
            var sqlPagination = new SqlPagination(offset, fetch);

            // Act
            var sut = await PersonRepository.GetPersons(sqlPagination);
            
            // Assert
            sut.Should()
                .NotBeEmpty("because because the method should not return an empty list.")
                .And.ContainItemsAssignableTo<Person>("because the list returned should be a list of type person.")
                .And.HaveCount(x => x > 0, "because the GetPerson method should not return 0 rows.");
        }
    }
}