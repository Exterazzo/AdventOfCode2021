using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");
            var course = new Course();
            var depth = 0;
            var aim = 0;
            foreach (var line in input)
            {
                var command = new Command(line);
                course.Add(command);
                if (!command.IsHorizontal)
                {
                    aim = course.GetAim();
                }
                else
                {
                    depth += (aim * command.AbsoluteUnits);
                }
            }

            var horizontalPosition = course.GetHorizontalPosition();
            var multiplied = horizontalPosition * depth;
            Console.WriteLine($"{horizontalPosition} x {depth} = {multiplied}");
            Console.ReadLine();
        }
    }
}
