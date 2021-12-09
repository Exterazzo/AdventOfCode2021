﻿using AdventOfCode.Interfaces;
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
            return 0;
        }


        public int GetSecondAnswer()
        {
            return 0;
        }
    }
}