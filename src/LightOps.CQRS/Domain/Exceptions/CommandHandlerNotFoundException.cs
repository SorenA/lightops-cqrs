using System;

namespace LightOps.CQRS.Domain.Exceptions
{
    public class CommandHandlerNotFoundException : Exception
    {
        private readonly Type _commandType;
        private readonly Type _resultType;

        public CommandHandlerNotFoundException(Type commandType, string message = null)
            : base(message ?? $"CommandHandler not found for Command {commandType}.")
        {
            _commandType = commandType;
        }
        public CommandHandlerNotFoundException(Type commandType, Type resultType, string message = null)
            : base(message ?? $"CommandHandler not found for Command {commandType} with result {resultType}.")
        {
            _commandType = commandType;
            _resultType = resultType;
        }
    }
}