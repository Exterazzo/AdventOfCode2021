using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day08
{
    public class Exercise : IExercise<int, int>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day8.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var digitCount = new Dictionary<int, int>();
            digitCount.Add(2, 1); // 2 digits equals the number 1
            digitCount.Add(4, 4); // 4 digits equals the number 4
            digitCount.Add(3, 7); // 3 digits equals the number 7
            digitCount.Add(7, 8); // 7 digits equals the number 8
            var sum = 0;
            foreach (var l in _input)
            {
                var data = l.Split(" | ");
                var uniqueSignalPatterns = data[0];
                var outputValue = data[1];
                sum += GetReadableDigitCount(outputValue, digitCount);
            }

            return sum;
        }

        private int GetReadableDigitCount(string outputValue, Dictionary<int, int> digitCount)
        {
            var count = 0;
            var data = outputValue.Split(' ');
            foreach (var d in data)
            {
                if (digitCount.ContainsKey(d.Length))
                    count++;
            }

            return count;
        }

        public int GetSecondAnswer()
        {
            var sum = 0;
            foreach (var l in _input)
            {
                var data = l.Split(" | ");
                var uniqueSignalPatterns = GetHenk(data[0]);
                var outputValues = data[1].Split(' ');

                var lineValue = string.Empty;

                foreach (var v in outputValues)
                { 
                    var match = uniqueSignalPatterns.FirstOrDefault(p => HasMatch(v, p.Input));
                    lineValue += match.NumericValue.ToString();
                }

                sum += Convert.ToInt32(lineValue);
            }

            return sum;
        }

        public List<Value> GetHenk(string line)
        {
            var data = line.Split(' ');
            var list = new List<Value>();
            foreach (var d in data)
            {
                list.Add(new Value() { Input = d, NumericValue = GetValue(d, data.ToList()) });
            }

            return list;
        }

        private int GetValue(string s, List<string> data)
        {
            var digitCount = new Dictionary<int, int>();
            digitCount.Add(1, 2); // 2 digits equals the number 1
            digitCount.Add(4, 4); // 4 digits equals the number 4
            digitCount.Add(7, 3); // 3 digits equals the number 7
            digitCount.Add(8, 7); // 7 digits equals the number 8
            var digitLetters = CreateMapping(data);

            if (digitCount.ContainsValue(s.Length))
                return digitCount.First(c => c.Value == s.Length).Key;

            foreach (var l in digitLetters)
            {
                if (HasMatch(s, l.Key))
                    return l.Value;
            }

            return -1;
        }

        private Dictionary<string, int> CreateMapping(List<string> data)
        {
            var zeroSixOrNine = data.Where(d => d.Length == 6).ToList();
            var twoThreeOrFive = data.Where(d => d.Length == 5).ToList();
            
            var one = data.First(d => d.Length == 2);
            var four = data.First(d => d.Length == 4);
            var seven = data.First(d => d.Length == 3);
            var eight = data.First(d => d.Length == 7);

            var nine = string.Empty;
            var six = string.Empty;
            var zero = string.Empty;
            foreach (var n in zeroSixOrNine)
            {
                if (HasSimpleMatch(n, four))
                {
                    nine = n;
                }
                else if (HasSimpleMatch(eight, n) && !HasSimpleMatch(n, seven))
                {
                    six = n;
                }
                else
                {
                    zero = n;
                }
            }

            var two = string.Empty;
            var three = string.Empty;
            var five = string.Empty;
            foreach (var n in twoThreeOrFive)
            {
                if (HasSimpleMatch(six, n))
                {
                    five = n;
                }
                else if (!HasSimpleMatch(nine, n))
                {
                    two = n;
                }
                else
                {
                    three = n;
                }
            }

            // twee zit niet in de 9, 3 en de 5 wel
            // 5 zit in de 6, 2,3 niet


            var digitLetters = new Dictionary<string, int>();
            digitLetters.Add(zero, 0);
            digitLetters.Add(two, 2);
            digitLetters.Add(three, 3);
            digitLetters.Add(five, 5);
            digitLetters.Add(six, 6);
            digitLetters.Add(nine, 9);
            return digitLetters;
        }

        private bool HasMatch(string input, string toMatch)
        {
            return toMatch.All(c => input.Contains(c)) && input.Length == toMatch.Length;
        }

        private bool HasSimpleMatch(string input, string toMatch)
        {
            return toMatch.All(c => input.Contains(c));
        }
    }
}
