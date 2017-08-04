using System.Collections.Generic;
using System.Linq;

namespace Tdd.Exercise1a
{
    public class PrimeNumbersGenerator
    {
        public IEnumerable<int> Generate(int limit)
        {
            if (limit <= 1)
            {
                return Enumerable.Empty<int>();
            }

            var primes = new List<int>();

            foreach (var number in Enumerable.Range(1, limit).Skip(1))
            {
                var divisors = primes.TakeWhile(p => p * p <= limit);

                if (divisors.All(d => number % d != 0))
                {
                    primes.Add(number);
                }
            }

            return primes;
        }
    }
}
