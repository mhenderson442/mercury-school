using System;

namespace MercurySchool.Functions.Models
{
    public class Person
    {
        private readonly int id;
        private readonly string firstName;
        private readonly string middleName;
        private readonly string lastName;

        public int Id{
            get => id;
            init => id = value;
        }

        public string FirstName
        {
            get => firstName;
            init => firstName = (value ?? throw new ArgumentNullException(nameof(FirstName)));
        }

        public string MiddleName
        {
            get => middleName;
            init => middleName = value;
        }

        public string LastName
        {
            get => lastName;
            init => lastName = (value ?? throw new ArgumentException(nameof(LastName)));
        }


    }
}