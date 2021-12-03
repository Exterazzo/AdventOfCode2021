using System;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Day02
{
    class Exercise : IExercise<int, int>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day2.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var course = new Course();
            foreach (var line in _input)
            {
                course.Add(new Command(line));
            }

            var horizontalPosition = course.GetHorizontalPosition();
            var depth = course.GetAim();

            var multiplied = horizontalPosition * depth;
            return multiplied;
        }

        public int GetSecondAnswer()
        {
            var course = new Course();
            var depth = 0;
            var aim = 0;
            foreach (var line in _input)
            {
                var command = new Command(line);
                course.Add(command);
                if (!command.IsHorizontal)
                {
                    aim = course.GetAim();
                }
                else
                {
                    depth += (aim * command.AbsoluteUnits);
                }
            }

            var horizontalPosition = course.GetHorizontalPosition();
            var multiplied = horizontalPosition * depth;
            return multiplied;
        }
    }
}
