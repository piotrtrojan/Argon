namespace Argon.Webapp.Utils
{
    public class CommandConnectionStringWrapper
    {
        public string Value { get; }

        public CommandConnectionStringWrapper(string commandsConnectionString)
        {
            Value = commandsConnectionString;
        }
    }
}
