namespace VMUtils.Interfaces
{
    public interface IFileWriter<in T>
    {
        /// <summary>
        /// Writes File to disk
        /// </summary>
        /// <param name="inputObject"></param>
        void Save(T inputObject);

        /// <summary>
        /// Locks object for editing
        /// </summary>
        void LockFile();

        /// <summary>
        /// Unlocks object
        /// </summary>
        /// <returns></returns>
        bool UnlockFile();
    }
}
