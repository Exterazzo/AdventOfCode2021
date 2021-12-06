using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day06
{
    public class Exercise : IExercise<int, long>
    {
        private string[] _input;
        private int _daysExerciseOne = 80;
        private int _daysExerciseTwo = 256;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day6.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var school = new SchoolOfFish(_input[0]);
            Console.WriteLine($"Initial state: {school}");
            for(var d = 1; d <= _daysExerciseOne; d++)
            {
                school.PassDay();
                Console.WriteLine($"After {d} days: {school.Count}");
            }
            return school.Count;
        }

        public long GetSecondAnswer()
        {
            var fish = _input[0].Split(',').Select(f => Convert.ToInt32(f)).ToList();
            var school = GetEmptyDictionary();

            // init input
            foreach (var i in fish) {
                school[i]++;
            }

            for (var d = 1; d <= _daysExerciseTwo; d++)
            {
                var newSchool = GetEmptyDictionary();
                var newBorns = school[0];

                foreach(var f in school)
                {
                    if (f.Key > 0)
                        newSchool[f.Key - 1] = f.Value;
                }
                newSchool[8] = newBorns;
                newSchool[6] += newBorns;

                school = newSchool;
                Console.WriteLine($"After {d} days: {GetFishCount(school)}");
                
            }
            return GetFishCount(school);
        }

        private long GetFishCount(Dictionary<int, long> school)
        {
            return school.Select(f => f.Value).Sum();
        }

        private Dictionary<int, long> GetEmptyDictionary()
        {
            var school = new Dictionary<int, long>();
            // init dictionary
            for (var i = 0; i <= 8; i++)
            {
                school.Add(i, 0);
            }
            return school;
        }
    }
}
