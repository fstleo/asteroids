namespace Game.Core.Interfaces
{
    public interface IBuildPipeline<T>
    {
        void SetNext(IBuildPipeline<T> pipeline);

        T Build(T obj);
    }
}