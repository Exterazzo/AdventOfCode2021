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
            foreach(var i in input)
            {
                Add(new Row(i));
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

        private List<LowPoint> GetLowestPoints(List<LowPoint> lowPoints, int i)
        {
            var actualPoints = new List<LowPoint>();
            foreach (var p in lowPoints)
            {
                int? above = null;
                int? below = null;
                if (i > 0)
                    above = this[i - 1].Single(l => l.Index == p.Index).Value;

                if (i < this.Count - 1)
                    below = this[i + 1].Single(l => l.Index == p.Index).Value;


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
