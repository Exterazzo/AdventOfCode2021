using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    class Board
    {
        private List<Line> _rows = new List<Line>();
        private List<Line> _columns = new List<Line>();
        
        public Board(List<string> lines)
        {
            foreach (var line in lines)
            {
                _rows.Add(new Line(line));
            }

            for (var i = 0; i < _rows[0].Count; i++)
            {
                var numbers = new List<int>();
                foreach (var row in _rows)
                {
                    numbers.Add(row[i].Number);
                }
                _columns.Add(new Line(numbers));
            }
        }

        public void DrawNumber(int number)
        {
            foreach (var row in _rows)
            {
                row.DrawNumber(number);
            }

            foreach (var col in _columns)
            {
                col.DrawNumber(number);
            }
        }

        public int GetUnmarkedSum()
        {
            return _rows.Sum(r => r.GetUnmarkedSum());
        }

        public bool HasBingo()
        {
            return _rows.Any(r => r.HasBingo()) || _columns.Any(c => c.HasBingo());
        }
    }
}
