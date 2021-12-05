using System;
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
                else if (Math.Abs(Start.X - End.X) == Math.Abs(Start.Y - End.Y))
                    return Direction.Diagonal;

                return Direction.Other;
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
            else if (Direction == Direction.Diagonal)
                points.AddRange(GetDiagonalPoints());
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

        private List<Point> GetDiagonalPoints()
        {
            var x = Start.X;
            var y = Start.Y;
            var xFactor = Start.X > End.X ? -1 : 1;
            var yFactor = Start.Y > End.Y ? -1 : 1;

            var points = new List<Point>();

            while(true)
            {
                x += xFactor;
                y += yFactor;
                var p = new Point() {X = x, Y = y};
                
                if (p.X == End.X && p.Y == End.Y)
                    break;

                points.Add(p);
            }
            
            return points;
        }
    }
}
