using AdventOfCode.Interfaces;
using System;

namespace AdventOfCode.Day06
{
    public class Exercise : IExercise<int, int>
    {
        private string[] _input;
        private int _days = 256;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day6.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var school = new SchoolOfFish(_input[0]);
            Console.WriteLine($"Initial state: {school}");
            for(var d = 0; d < _days; d++)
            {
                school.PassDay();
                Console.WriteLine($"After {d} days: {school.Count}");
            }
            return school.Count;
        }

        public int GetSecondAnswer()
        {
            return 0;
        }
    }
}
