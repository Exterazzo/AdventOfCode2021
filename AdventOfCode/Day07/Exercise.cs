using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day07
{
    public class Exercise : IExercise<int, long>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day7.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var currentPositions = _input[0].Split(',').Select(i => Convert.ToInt32(i)).ToList();
            var minPosition = currentPositions.Min();
            var maxPosition = currentPositions.Max();
            var steps = new Dictionary<int, int>();
            for(var i = minPosition; i <= maxPosition; i++)
            {
                steps.Add(i, GetFuelCount(currentPositions, i));
            }
            return steps.Select(s => s.Value).Min();
        }

        private int GetFuelCount(List<int> currentPositions, int i)
        {
            var fuel = 0;
            foreach(var p in currentPositions)
            {
                fuel += Math.Abs(p - i);
            }
            return fuel;
        }

        public long GetSecondAnswer()
        {
            var currentPositions = _input[0].Split(',').Select(i => Convert.ToInt32(i)).ToList();
            var minPosition = currentPositions.Min();
            var maxPosition = currentPositions.Max();
            var steps = new Dictionary<int, int>();
            for (var i = minPosition; i <= maxPosition; i++)
            {
                steps.Add(i, GetNewFuelCount(currentPositions, i));
            }
            return steps.Select(s => s.Value).Min();
        }

        private int GetNewFuelCount(List<int> currentPositions, int i)
        {
            var fuel = 0;
            foreach (var p in currentPositions)
            {
                var diff = Math.Abs(p - i);
                fuel += SumToF(diff);
            }
            return fuel;
        }

        private int SumToF(int f)
        {
            var burnedFuel = 0;
            for(var i = f; i > 0; i--)
            {
                burnedFuel += i;
            }
            return burnedFuel;
        }
    }
}
