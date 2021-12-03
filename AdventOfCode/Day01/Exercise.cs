using System;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Day01
{
    class Exercise : IExercise<int, int>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day1.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var largerThanPrevious = 0;
            var previous = int.MaxValue;
            foreach (var s in _input)
            {
                var i = Convert.ToInt32(s);
                if (i > previous)
                    largerThanPrevious++;


                previous = i;
            }

            return largerThanPrevious;
        }

        public int GetSecondAnswer()
        {
            var largerThanPrevious = 0;
            var previous = new Measurement(9999, 9999, 9999);
            for (var i = 0; i < _input.Length - 2; i++)
            {
                var a = Convert.ToInt32(_input[i]);
                var b = Convert.ToInt32(_input[i + 1]);
                var c = Convert.ToInt32(_input[i + 2]);

                var m = new Measurement(a, b, c);
                if (m.Sum > previous.Sum)
                    largerThanPrevious++;


                previous = m;
            }

            return largerThanPrevious;
        }
    }
}
