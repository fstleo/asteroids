namespace Game.Core.Interfaces
{
    public interface ICommandExecutor
    {
        void Execute(ICommand command);
    }
}