using System;

namespace Argon.Webapp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class CommandLogAtribute : Attribute
    {
        public CommandLogAtribute()
        {
        }
    }
}
