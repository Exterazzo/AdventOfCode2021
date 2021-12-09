using System;
using System.Collections.Generic;
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
    }
}
