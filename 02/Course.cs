using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Course : List<Command>
    {
        public int GetHorizontalPosition()
        {
            return this.Where(c => c.Direction == "forward").Select(c => c.Units).Sum();
        }

        public int GetDepth()
        {
            return this.Where(c => c.Direction != "forward").Select(c => c.AbsoluteUnits).Sum();
        }
    }
}
