﻿using Argon.Webapp.Commands;
using Argon.Webapp.Utils;

namespace Argon.Webapp.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        CommandResult Handle(TCommand command);
    }
}