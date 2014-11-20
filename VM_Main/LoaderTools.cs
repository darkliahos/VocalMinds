using System;

namespace VM_Main
{
    public static class LoaderTools
    {
        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <param name="min">minimum range</param>
        /// <param name="max">maximum range</param>
        /// <returns></returns>
        public static int RandomGenerator(int min, int max)
        {
            //TODO INVESTIGATE if the .Net Random function apparantly is a bit broken
            var random = new Random();
            return random.Next(min, max);
        }
    }
}