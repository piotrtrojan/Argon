using Argon.Webapp.CommandHandlers;
using Argon.Webapp.Commands;
using System;

namespace Argon.Webapp.Utils
{
    public class Messages
    {
        private readonly IServiceProvider _provider;
        public Messages(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }

        public Result Dispatch(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(new[] { command.GetType() });
            dynamic handler = _provider.GetService(handlerType);
            Result result = handler.Handle((dynamic)command);
            return result;
        }
    }
}
