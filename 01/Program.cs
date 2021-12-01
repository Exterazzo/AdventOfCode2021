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
            var previous = new Measurement(9999, 9999, 9999);
            for(var i = 0; i < input.Length - 2; i++)
            {
                var a = Convert.ToInt32(input[i]);
                var b = Convert.ToInt32(input[i+1]);
                var c = Convert.ToInt32(input[i+2]);

                var m = new Measurement(a, b, c);
                if (m.Sum > previous.Sum)
                    largerThanPrevious++;


                previous = m;
            }

            Console.WriteLine(largerThanPrevious);
            Console.ReadLine();
        }
    }
}
