using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");
            var course = new Course();
            foreach (var line in input)
            {
                course.Add(new Command(line));
            }

            var horizontalPosition = course.GetHorizontalPosition();
            var depth = course.GetDepth();

            var multiplied = horizontalPosition * depth;
            Console.WriteLine($"{horizontalPosition} x {depth} = {multiplied}");
            Console.ReadLine();
        }
    }
}
