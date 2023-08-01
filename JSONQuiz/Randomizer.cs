using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONQuiz
{
    public static class Randomizer
    {
        private static readonly Random _generator = new Random();
        public static int GetRandomNumber(int maxValue)
        {
            byte[] randomByte = new byte[1];
            _generator.NextBytes(randomByte);
            double asciValueOfRandomChar = Convert.ToDouble(randomByte[0]);
            double multiplier = Math.Max(0, (asciValueOfRandomChar / 255d) - 0.00000000001d);
            double randomValueInRange = Math.Floor(multiplier * maxValue);
            return (int)(1 + randomValueInRange);
        }
        public static List<int> GetListOfRandomNumbers(int amount, int maxValue)
        {
            var result = new List<int>();
            while(result.Count < amount)
            {
                int rnd = GetRandomNumber(maxValue);
                if (!result.Contains(rnd))
                {
                    result.Add(rnd);
                }
            }

            return result;
        }
    }
}
