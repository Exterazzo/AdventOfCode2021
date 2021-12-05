using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Day05
{
    public class Exercise : IExercise<int, int>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day5.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        private Vents GetVectors()
        {
            var vectors = new Vents();
            foreach (var line in _input)
            {
                vectors.Add(new Vector(line));
            }

            return vectors;
        }

        public int GetFirstAnswer()
        {
            var vectors = GetVectors();

            var floor = new OceanFloor(vectors);
            //floor.Draw();
            return floor.GetDangerousPointCount();
        }

        public int GetSecondAnswer()
        {
            return 0;
        }
    }
}
