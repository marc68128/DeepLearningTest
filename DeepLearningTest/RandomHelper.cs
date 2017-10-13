using System;
using System.Diagnostics;

namespace DeepLearningTest
{
    public static class RandomHelper
    {
        private static readonly Random _rand;

        static RandomHelper()
        {
            _rand = new Random();
        }

        public static double NextDouble()
        {
            var val = _rand.NextDouble();
            return val;
        }

        public static int Next(int minVal, int maxVal)
        {
            return _rand.Next(minVal, maxVal);
        }
    }
}