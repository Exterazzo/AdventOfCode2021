using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Day10
{
    public class Exercise : IExercise<int, long>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day10.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var list = new List<SyntaxLine>();
            foreach(var l in _input)
                list.Add(new SyntaxLine(l));

            var corrupted = list.Where(l => l.IsCorrupted).Select(l => l.CorruptedCharacter).ToList();

            var sum = 0;
            foreach (var c in corrupted)
            {
                if (c == ')')
                    sum += 3;
                if (c == ']')
                    sum += 57;
                if (c == '}')
                    sum += 1197;
                if (c == '>')
                    sum += 25137;
            }

            return sum;
        }


        public long GetSecondAnswer()
        {
            var list = new List<SyntaxLine>();
            foreach (var l in _input)
                list.Add(new SyntaxLine(l));

            var incomplete = list.Where(l => !l.IsCorrupted).ToList();
            var scores = new List<long>();
            foreach(var l in incomplete)
            {
                scores.Add(l.GetScore());
            }

            scores = scores.OrderBy(s => s).ToList();

            return scores[scores.Count / 2];
        }
    }
}
