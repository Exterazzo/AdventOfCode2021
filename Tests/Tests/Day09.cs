using System;
using AdventOfCode.Day09;
using FluentAssertions;
using Xunit;

namespace Tests.Tests
{
    public class Day09 
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
            firstAnswer.Should().Be(15);
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
            secondAnswer.Should().Be(1134);
        }

        private string[] GetSampleInput()
        {
            var input = @"2199943210
3987894921
9856789892
8767896789
9899965678";
            return input.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );
        }
    }
}
