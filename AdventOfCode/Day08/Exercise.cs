using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day08
{
    public class Exercise : IExercise<int, int>
    {
        private string[] _input;
        
        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day8.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var digitCount = new Dictionary<int, int>();
            digitCount.Add(2, 1); // 2 digits equals the number 1
            digitCount.Add(4, 4); // 4 digits equals the number 4
            digitCount.Add(3, 7); // 3 digits equals the number 7
            digitCount.Add(7, 8); // 7 digits equals the number 8
            var sum = 0;
            foreach (var l in _input)
            {
                var data = l.Split(" | ");
                var uniqueSignalPatterns = data[0];
                var outputValue = data[1];
                sum += GetReadableDigitCount(outputValue, digitCount);
            }

            return sum;
        }

        private int GetReadableDigitCount(string outputValue, Dictionary<int, int> digitCount)
        {
            var count = 0;
            var data = outputValue.Split(' ');
            foreach (var d in data)
            {
                if (digitCount.ContainsKey(d.Length))
                    count++;
            }
            return count;
        }

        public int GetSecondAnswer()
        {
            return 0;
        }
    }
}
