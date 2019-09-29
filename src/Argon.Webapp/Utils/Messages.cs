using Argon.Webapp.CommandHandlers;
using Argon.Webapp.Commands;
using Argon.Webapp.Queries;
using Argon.Webapp.QueryHandlers;
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

        public CommandResult Dispatch(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(new[] { command.GetType() });
            dynamic handler = _provider.GetService(handlerType);
            CommandResult result = handler.Handle((dynamic)command);
            return result;
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(new[] { query.GetType(), typeof(T) });
            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);
            return result;
        }
    }
}
