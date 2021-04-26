using MercurySchool.Functions.Functions;

namespace MercurySchool.Functions.UnitTests.FunctionTests
{
    public class PersonFunctionsTests
    {

        public PersonFunctionsTests() => PersonFunctions = new PersonFunctions();
        private PersonFunctions _personFunctions;

        public PersonFunctions PersonFunctions
        {
            get => _personFunctions;
            set => _personFunctions = value;
        }
    }
}