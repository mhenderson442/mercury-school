namespace MercurySchool.Api.Models
{
    /// <summary>
    /// IPerson interface
    /// </summary>
    internal interface IPerson : IAccount
    {
        /// <summary>
        /// Person's first name
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Person's Id
        /// </summary>
        string Id { get; init; }

        /// <summary>
        /// Person's last name
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Person's middle name (optional)
        /// </summary>
        string? MiddleName { get; set; }

        /// <summary>
        /// Item type stored in Person database container
        /// </summary>
        string ItemType { get; }

        /// <summary>
        /// Person's student record
        /// </summary>
        Student? Student { get; set; }
        }
}