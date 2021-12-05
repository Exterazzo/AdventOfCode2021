using System.Collections.Generic;

namespace AdventOfCode.Day05
{
    class Vector
    {
        public Point Start;
        public Point End;

        public Vector(string input)
        {
            var data = input.Split(' ');
            Start = new Point(data[0]);
            End = new Point(data[2]);
        }

        public Direction Direction
        {
            get
            {
                if (Start.X == End.X)
                    return Direction.Vertical;
                else if (Start.Y == End.Y)
                    return Direction.Horizontal;

                return Direction.Diagonal;
            }
        }

        public List<Point> GetOverlappingPoints()
        {
            var points = new List<Point>();
            points.Add(Start);
            if (Direction == Direction.Horizontal)
                points.AddRange(GetHorizontalPoints());
            else if (Direction == Direction.Vertical)
                points.AddRange(GetVerticalPoints());
            points.Add(End);
            return points;
        }

        private List<Point> GetHorizontalPoints()
        {
            var startX = Start.X < End.X ? Start.X : End.X;
            var endX = Start.X > End.X ? Start.X : End.X;
            var points = new List<Point>();
            for (var x = startX + 1; x < endX; x++)
            {
                points.Add(new Point() { X = x, Y = Start.Y});
            }
            return points;
        }

        private List<Point> GetVerticalPoints()
        {
            var startY = Start.Y < End.Y ? Start.Y : End.Y;
            var endY = Start.Y > End.Y ? Start.Y : End.Y;
            var points = new List<Point>();
            for (var y = startY + 1; y < endY; y++)
            {
                points.Add(new Point() { X = Start.X, Y = y });
            }
            return points;
        }
    }
}
