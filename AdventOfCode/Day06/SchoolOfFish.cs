using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day06
{
    class SchoolOfFish : List<LanternFish>
    {
        private List<LanternFish> _babyFish = new List<LanternFish>();
        
        public SchoolOfFish(string input)
        {
            var fish = input.Split(',');
            foreach(var f in fish)
            {
                var lanternFish = new LanternFish(Convert.ToInt32(f));
                lanternFish.BabyBorn += LanternFish_BabyBorn;
                this.Add(lanternFish);
            }
        }

        private void LanternFish_BabyBorn(object sender, EventArgs e)
        {
            var fish = new LanternFish();
            fish.BabyBorn += LanternFish_BabyBorn;
            _babyFish.Add(fish);
        }

        internal void PassDay()
        {
            _babyFish.Clear();
            foreach (var f in this)
            {
                f.PassDay();
            }
            this.AddRange(_babyFish);
        }
        public override string ToString()
        {
            var school = this.Select(f => f.ToString()).ToList();
            return string.Join(',', school); 
        }
    }
}
