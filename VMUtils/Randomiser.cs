using System;

namespace VM_Main
{
    public static class Randomiser
    {

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <param name="min">minimum range</param>
        /// <param name="max">maximum range</param>
        /// <returns></returns>
        public static int RandomGenerator(int min, int max)
        {
            lock (syncLock)
            { 
                return random.Next(min, max);
            }
        }

    }
}