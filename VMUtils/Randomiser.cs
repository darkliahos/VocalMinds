using System;

namespace VMUtils
{
    public static class Randomiser
    {

        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();

        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <param name="min">minimum range</param>
        /// <param name="max">maximum range</param>
        /// <returns></returns>
        public static int NextRange(int min, int max)
        {
            lock (SyncLock)
            { 
                return Random.Next(min, max);
            }
        }

    }
}