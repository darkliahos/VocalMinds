namespace VMUtils.Interfaces
{
    public interface IMerge<T>
    {
        /// <summary>
        /// Indicates if there are any differences between the source and target
        /// </summary>
        /// <param name="source">Source object (this should be from source</param>
        /// <param name="target">Target object (Currently edited object)</param>
        /// <returns></returns>
        bool CompareSourceWithTarget(T source, T target);

        /// <summary>
        /// Performs the merge
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        T MergeFiles(T source, T target);
    }
}
