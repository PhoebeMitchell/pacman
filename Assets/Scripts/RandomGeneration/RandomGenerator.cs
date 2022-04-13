using System;

namespace RandomGeneration
{
    public class RandomGenerator : IRandom
    {
        private readonly Random _random;

        public RandomGenerator(string seed = "")
        {
            _random = seed == "" ? new Random() : new Random(seed.GetHashCode());
        }
        
        public float Next()
        {
            return _random.Next();
        }
    }
}