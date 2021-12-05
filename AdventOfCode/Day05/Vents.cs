using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day05
{
    class Vents: List<Vector>
    {
        public Point GetOceanFloorSize()
        {
            var x = this.Select(v => v.Start.X).Union(this.Select(v => v.End.X)).Max();
            var y = this.Select(v => v.Start.Y).Union(this.Select(v => v.End.Y)).Max();
            return new Point() {X = x, Y = y};
        }

        public List<Vector> GetHorizonalAndVerticalVectors()
        {
            return this.Where(v => v.Direction == Direction.Horizontal || v.Direction == Direction.Vertical).ToList();
        }
    }
}
