using Argon.Webapp.CommandHandlers;
using Argon.Webapp.Commands;
using Argon.Webapp.Utils;
using Newtonsoft.Json;
using System;

namespace Argon.Webapp.Decorators
{
    public class CommandLogDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;

        public CommandLogDecorator(ICommandHandler<TCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public CommandResult Handle(TCommand command)
        {
            var commandContent = JsonConvert.SerializeObject(command);
            Console.WriteLine($"Command of type {command.GetType().Name}: {commandContent}");
            return _commandHandler.Handle(command);
        }
    }
}
