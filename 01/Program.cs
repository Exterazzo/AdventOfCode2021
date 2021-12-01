using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Projects\AdventOfCode2021\01\input.txt";
            var input = System.IO.File.ReadAllLines(path);

            var largerThanPrevious = 0;
            var previous = int.MaxValue;
            foreach(var s in input)
            {
                var i = Convert.ToInt32(s);
                if (i > previous)
                    largerThanPrevious++;


                previous = i;
            }

            Console.WriteLine(largerThanPrevious);
            Console.ReadLine();
        }
    }
}
