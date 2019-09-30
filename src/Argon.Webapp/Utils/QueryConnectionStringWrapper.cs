namespace Argon.Webapp.Utils
{
    public class QueryConnectionStringWrapper
    {
        public string Value { get; }
        public QueryConnectionStringWrapper(string queriesConnectionString)
        {
            Value = queriesConnectionString;
        }

    }
}
