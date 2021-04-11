using System.Collections.Generic;
using System.Threading.Tasks;
using MercurySchool.Functions.Models;

namespace MercurySchool.Functions.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPersons(SqlPagination sqlPagination);
    }
}