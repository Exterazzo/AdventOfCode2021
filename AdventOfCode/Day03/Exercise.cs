using System;
using System.Linq;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Day03
{
    public class Exercise : IExercise<int, int>
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
            var oxygenGeneratorRating = GetOxygenGeneratorRating();
            var co2ScrubberRating = GetCO2ScrubberRating();

            return oxygenGeneratorRating * co2ScrubberRating;
        }

        private int GetCO2ScrubberRating()
        {
            var bits = _input[0].Length;

            var items = _input;
            for (var i = 0; i < bits; i++)
            {
                items = GetMatchingItems(items, i, '0');
                if (items.Length == 1)
                    break;
            }


            return Convert.ToInt32(items.First(), 2);
        }

        private int GetOxygenGeneratorRating()
        {
            var bits = _input[0].Length;

            var items = _input;
            for (var i = 0; i < bits; i++)
            {
                items = GetMatchingItems(items, i, '1');
            }
            

            return Convert.ToInt32(items.First(), 2);
        }

        private string[] GetMatchingItems(string[] input, int index, char determinator)
        {
            var bitCount = 0;
            var lineCount = input.Length;
            foreach (var binary in input)
            {
                if (binary[index] == '1')
                    bitCount++;
            }


            var half = (decimal) lineCount / 2;

            var bitCriteria = '0';
            // Equal number of bits
            if (bitCount == half)
            {
                bitCriteria = determinator;
            }
            else if (bitCount > half)
            {
                bitCriteria = determinator == '1' ? '1' : '0';
            }
            else
            {
                bitCriteria = determinator == '1' ? '0' : '1';
            }

            // Find all items matching bit criteria for the given index position
            var matchingItems = input.Where(i => i[index] == bitCriteria).ToList();

            return matchingItems.ToArray();
        }
        
    }
}
