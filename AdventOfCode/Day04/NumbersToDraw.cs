using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    public class NumbersToDraw : List<int>
    {
        public NumbersToDraw(string numbers)
        {
            this.AddRange(numbers.Split(',').Select(n => Convert.ToInt32(n)));
        }
    }
}
