namespace Finances.Infra.Common
{
    public interface ICommandHandler<T> where T : ICommandDefault
    {
        Task<ICommandResult> Handle(T command);
    }
}
