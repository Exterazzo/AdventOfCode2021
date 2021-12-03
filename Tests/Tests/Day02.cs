using System;
using AdventOfCode.Day02;
using FluentAssertions;
using Xunit;

namespace Tests.Tests
{
    public class Day02
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
            firstAnswer.Should().Be(150);
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
            secondAnswer.Should().Be(900);
        }

        private string[] GetSampleInput()
        {
            var input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            return input.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );
        }
    }
}
