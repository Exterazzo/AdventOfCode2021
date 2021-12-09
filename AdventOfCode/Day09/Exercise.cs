using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class Exercise : IExercise<int, int>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day9.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var map = new Map(_input);
            var lowPoints = map.GetLowPoints();
            var sum = lowPoints.Select(p => p.Value + 1).Sum();
            return sum;
        }


        public int GetSecondAnswer()
        {
            var map = new Map(_input);
            var lowPoints = map.GetLowPoints();

            var bassins = new Dictionary<Bassin, int>();
            foreach (var p in lowPoints)
            {
                var bassin = map.GetBassinForPoint(p, new Bassin());
                var size = bassin.GetSize();
                bassins.Add(bassin, size);
            }

            var topBassins = bassins.Select(b => b.Value).OrderByDescending(b => b).Take(3).ToList();

            return topBassins[0] * topBassins[1] * topBassins[2];
        }
    }
}
