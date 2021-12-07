using System;
using AdventOfCode.Day07;
using FluentAssertions;
using Xunit;

namespace Tests.Tests
{
    public class Day07
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
            firstAnswer.Should().Be(37);
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
            secondAnswer.Should().Be(0);
        }

        private string[] GetSampleInput()
        {
            var input = @"16,1,2,0,4,2,7,1,2,14";
            return input.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );
        }
    }
}
