using System;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Day03
{
    class Exercise : IExercise<int, int>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day3.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var bits = _input[0].Length;
            
            var bitCount = new int[bits];
            var lineCount = _input.Length;
            foreach (var binary in _input)
            {
                for (int i = 0; i < bits; i++)
                {
                    if (binary[i] == '1')
                        bitCount[i]++;
                }
            }

            var gamma = string.Empty;
            var epsilon = string.Empty;

            foreach (var c in bitCount)
            {
                if (c > (lineCount / 2))
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }
            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }

        public int GetSecondAnswer()
        {
            return 0;
        }

        
    }
}
