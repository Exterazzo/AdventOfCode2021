using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day09
{
    class Map : List<Row>
    {
        public Map(string[] input)
        {
            for (var y = 0; y < input.Length; y++)
            {
                Add(new Row(input[y], y));
            }
        }

        public List<LowPoint> GetLowPoints()
        {
            var d = new List<LowPoint>();
            for (var i = 0; i < this.Count; i++)
            {
                var p = this[i].GetLowPointsInRow();
                d.AddRange(GetLowestPoints(p, i));
            }
            
            return d;
        }

        private bool ContainsXY(List<LowPoint> list, LowPoint point)
        {
            return list.Any(p => p.X == point.X && p.Y == point.Y);
        }

        public Bassin GetBassinForPoint(LowPoint point, Bassin list)
        {
            var above = FindPoint(point.X, point.Y - 1);
            var below = FindPoint(point.X, point.Y + 1);
            var left = FindPoint(point.X - 1, point.Y);
            var right = FindPoint(point.X + 1, point.Y);

            var startCount = list.Count;

            if (!ContainsXY(list, point))
                list.Add(point);


            if (above.HasValue && above.Value.Value != 9 && !ContainsXY(list, above.Value))
                list.Add(above.Value);

            if (below.HasValue && below.Value.Value != 9 && !ContainsXY(list, below.Value))
                list.Add(below.Value);

            if (left.HasValue && left.Value.Value != 9 && !ContainsXY(list, left.Value))
                list.Add(left.Value);

            if (right.HasValue && right.Value.Value != 9 && !ContainsXY(list, right.Value))
                list.Add(right.Value);


            if (list.Count == startCount)
                return list;

            var recursiveList = new List<LowPoint>();

            foreach (var l in list.ToList())
            {
                recursiveList.AddRange(GetBassinForPoint(l, list));
            }

            foreach (var r in recursiveList)
            {
                if (!ContainsXY(list, r))
                    list.Add(r);
            }


            return list;
        }

        private LowPoint? FindPoint(int x, int y)
        {
            if (y >= 0 && y < this.Count && x >= 0 && x < this[0].Count)
            {
                return this[y].First(p => p.X == x);
            }

            return null;
        }

        private List<LowPoint> GetLowestPoints(List<LowPoint> lowPoints, int i)
        {
            var actualPoints = new List<LowPoint>();
            foreach (var p in lowPoints)
            {
                int? above = null;
                int? below = null;
                if (i > 0)
                    above = this[i - 1].Single(l => l.X == p.X).Value;

                if (i < this.Count - 1)
                    below = this[i + 1].Single(l => l.X == p.X).Value;


                if (above.HasValue && below.HasValue && p.Value < above.Value && p.Value < below.Value)
                    actualPoints.Add(p);

                else if (!above.HasValue && below.HasValue && p.Value < below.Value)
                    actualPoints.Add(p);

                else if (!below.HasValue && above.HasValue && p.Value < above.Value)
                    actualPoints.Add(p);
            }

            return actualPoints;
        }
    }
}
