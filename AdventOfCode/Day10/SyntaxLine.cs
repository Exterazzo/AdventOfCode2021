using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    class SyntaxLine
    {
        private string _line;
        private List<Chunk> _characters = new List<Chunk>();
        private Stack<char> _stack;
        
        public bool IsCorrupted;
        public char CorruptedCharacter;

        public SyntaxLine(string input)
        {
            _line = input;
            _characters.Add(new Chunk() { Start = '{', End = '}'});
            _characters.Add(new Chunk() { Start = '[', End = ']' });
            _characters.Add(new Chunk() { Start = '<', End = '>' });
            _characters.Add(new Chunk() { Start = '(', End = ')' });

            var startCharacters = _characters.Select(c => c.Start).ToList();
            var endCharacters = _characters.Select(c => c.End).ToList();

            _stack = new Stack<char>();
            foreach (var c in _line)
            {
                if (startCharacters.Contains(c))
                {
                    var chunk = _characters.First(h => h.Start == c || h.End == c);
                    _stack.Push(chunk.End);
                }
                else if (endCharacters.Contains(c))
                {
                    _stack.TryPop(out var expected);
                    if (expected != c)
                    {
                        IsCorrupted = true;
                        CorruptedCharacter = c;
                        break;
                    }
                }
            }
        }

        
    }
}
