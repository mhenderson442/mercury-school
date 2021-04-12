using System;

namespace MercurySchool.Functions.Models
{
    /// <summary>
    /// Class that defines properies of a person.
    /// </summary>
    public class Person
    {
        private readonly int? id;
        private readonly string firstName;
        private readonly string middleName;
        private readonly string lastName;

        /// <summary>
        /// Primary key stored in database.
        /// </summary>
        /// <value>int</value>
        public int? Id{
            get => id;
            init => id = value;
        }

        /// <summary>
        /// Person's first name.
        /// Null entries will throw an error.
        /// </summary>
        /// <value>string</value>
        public string FirstName
        {
            get => firstName;
            init => firstName = (value ?? throw new ArgumentNullException(nameof(FirstName)));
        }

        /// <summary>
        /// Person's middle name.
        /// </summary>
        /// <value>string</value>
        public string MiddleName
        {
            get => middleName;
            init => middleName = value;
        }

        /// <summary>
        /// Person's Last Name
        /// Null entries will throw an error.
        /// </summary>
        /// <value>string</value>
        public string LastName
        {
            get => lastName;
            init => lastName = (value ?? throw new ArgumentException(nameof(LastName)));
        }
    }
}