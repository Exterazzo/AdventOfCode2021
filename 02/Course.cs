using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Course : List<Command>
    {
        public int GetHorizontalPosition()
        {
            return this.Where(c => c.IsHorizontal).Select(c => c.AbsoluteUnits).Sum();
        }

        public int GetAim()
        {
            return this.Where(c => !c.IsHorizontal).Select(c => c.AbsoluteUnits).Sum();
        }
    }
}
