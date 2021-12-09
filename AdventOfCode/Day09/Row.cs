﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day09
{
    class Row : List<LowPoint>
    {
        public Row(string row)
        {
            
            for(var i = 0; i < row.Length; i++)
            {
                var n = Convert.ToInt32(row[i].ToString());
                int? p = null;
                int? next = null;
                if (i > 0)
                    p = Convert.ToInt32(row[i-1].ToString());

                if (i < row.Length - 1)
                    next = Convert.ToInt32(row[i+1].ToString());
                var point = new LowPoint() { Index = i, Value = n, Previous = p, Next = next };
                Add(point);
            }
        }

        public List<LowPoint> GetLowPointsInRow()
        {
            var l = new List<LowPoint>();
            foreach(var p in this)
            {
                
            }
            return l;
        }
    }
}