using System;
using System.Linq;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Day04
{
    public class Exercise : IExercise<int, int>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day4.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            return 0;
        }

        public int GetSecondAnswer()
        {
            return 0;
        }        
    }
}
