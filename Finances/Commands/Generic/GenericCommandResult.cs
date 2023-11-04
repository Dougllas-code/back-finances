using Finances.Infra.Common;
using Finances.Infra.Common.Enum;

namespace Finances.Commands.Generic
{
    public class GenericCommandResult: ICommandResult
    {
        public CommandResultType Type { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public GenericCommandResult(CommandResultType type, string message, object data)
        {
            Type = type;
            Message = message;
            Data = data;
        }
    }
}
