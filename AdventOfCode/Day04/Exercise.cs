using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Day04
{
    public class Exercise : IExercise<int, int>
    {
        private string[] _input;

        public Exercise()
        {
            _input = System.IO.File.ReadAllLines("Input\\day4.txt");
        }

        public Exercise(string[] input)
        {
            _input = input;
        }

        public int GetFirstAnswer()
        {
            var numbers = new NumbersToDraw(_input[0]);
            var boards = new List<Board>();
            var boardLines = new List<string>();
            for (var i = 2; i < _input.Length; i++)
            {
                if (_input[i].Length == 0)
                {
                    boards.Add(new Board(boardLines));
                    boardLines = new List<string>();
                }
                else
                {
                    boardLines.Add(_input[i]);
                }
            }
            boards.Add(new Board(boardLines));

            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    board.DrawNumber(number);
                    if (board.HasBingo())
                    {
                        var unmarkedSum = board.GetUnmarkedSum();
                        var lastDrawnNumber = number;
                        return unmarkedSum * lastDrawnNumber;
                    }
                }
            }
            return 0;
        }

        public int GetSecondAnswer()
        {
            return 0;
        }        
    }
}
