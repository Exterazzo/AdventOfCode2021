using System;
using System.Diagnostics;

namespace AdventOfCode.Day05
{
    [DebuggerDisplay("X = {X}, Y = {Y}")]
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(string input)
        {
            var data = input.Split(',');
            X = Convert.ToInt32(data[0]);
            Y = Convert.ToInt32(data[1]);
        }
    }
}
