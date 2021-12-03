using System;
using AdventOfCode.Day01;
using FluentAssertions;
using Xunit;

namespace Tests.Tests
{
    public class Day01
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
            firstAnswer.Should().Be(7);
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
            secondAnswer.Should().Be(5);
        }

        private string[] GetSampleInput()
        {
            var input = @"199
200
208
210
200
207
240
269
260
263";
            return input.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );
        }
    }
}
