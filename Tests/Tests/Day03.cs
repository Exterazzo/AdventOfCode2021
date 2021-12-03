using System;
using AdventOfCode.Day03;
using FluentAssertions;
using Xunit;

namespace Tests.Tests
{
    public class Day03
    {
        [Fact]
        public void Part1()
        {
            // Arrange
            var input = GetSampleInput();
            var exercise = new Exercise(input);

            // Act
            var firstAnswer = exercise.GetFirstAnswer();

            // Assert
            firstAnswer.Should().Be(198);
        }

        [Fact]
        public void Part2()
        {
            // Arrange
            var input = GetSampleInput();
            var exercise = new Exercise(input);

            // Act
            var secondAnswer = exercise.GetSecondAnswer();

            // Assert
            secondAnswer.Should().Be(230);
        }

        private string[] GetSampleInput()
        {
            var input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            return input.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );
        }
    }
}
