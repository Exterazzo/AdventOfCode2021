using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    class Line : List<BingoNumber>
    {
        public Line(string line)
        {
            var data = line.Split(' ').Where(n => n.Length > 0);
            this.AddRange(data.Select(StringToBingoNumber));
        }

        public Line(List<int> numbers)
        {
            AddRange(numbers.Select(n => new BingoNumber() {IsMarked = false, Number = n}));
        }

        public void DrawNumber(int number)
        {
            foreach (var bingoNumber in this)
            {
                if (bingoNumber.Number == number)
                    bingoNumber.IsMarked = true;
            }
        }

        public bool HasBingo()
        {
            return (this.All(n => n.IsMarked));
        }

        public int GetUnmarkedSum()
        {
            return this.Where(n => !n.IsMarked).Select(n => n.Number).Sum();
        }

        private BingoNumber StringToBingoNumber(string input)
        {
            return new BingoNumber() {IsMarked = false, Number = Convert.ToInt32(input)};
        }
    }
}
