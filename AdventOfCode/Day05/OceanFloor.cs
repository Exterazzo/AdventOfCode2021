using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day05
{
    class OceanFloor
    {
        private Vents _vents;
        private Dictionary<Point, int> _dangerousAreas;

        public OceanFloor(Vents vents, Direction[] directionsToCheck)
        {
            _vents = vents;
            _dangerousAreas = GetDangerousAreas(directionsToCheck);
        }

        private Dictionary<Point, int> GetDangerousAreas(Direction[] directionsToCheck)
        {
            var areas = new Dictionary<Point, int>();
            foreach (var v in _vents.GetByDirections(directionsToCheck))
            {
                foreach (var p in v.GetOverlappingPoints())
                {
                    if (areas.ContainsKey(p))
                        areas[p]++;
                    else
                        areas.Add(p, 1);
                }
            }

            return areas;
        }

        public int GetDangerousPointCount()
        {
            return _dangerousAreas.Count(a => a.Value > 1);
        }

        public void Draw()
        {
            var size = _vents.GetOceanFloorSize();
            for (var y = 0; y <= size.Y; y++)
            {
                for (var x = 0; x <= size.X; x++)
                {
                    var p = new Point() {X = x, Y = y};
                    if (_dangerousAreas.ContainsKey(p))
                        Console.Write(_dangerousAreas[p]);
                    else
                        Console.Write('.');
                }
                Console.WriteLine("");
            }
        }
    }
}
