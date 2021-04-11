namespace MercurySchool.Functions.Models
{
    public class SqlPagination
    {
        private readonly int? _offset;
        private readonly int? _fetch;

        public SqlPagination(int? offset = null, int? fetch = null)
        {
            Offset = offset;
            Fetch = fetch;
        }
        public int? Offset { get => _offset; init => _offset = value; }

        public int? Fetch { get => _fetch; init => _fetch = value; }
    }
}