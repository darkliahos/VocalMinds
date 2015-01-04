namespace VMUtils.Interfaces
{
    public interface IMerge<T>
    {
        bool CompareSourceWithTarget(T source, T target);

        T MergeFiles(T source, T target);
    }
}
