using Finances.Infra.Common.Enum;

namespace Finances.Infra.Common
{
    public interface ICommandResult
    {
        public CommandResultType Type { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
