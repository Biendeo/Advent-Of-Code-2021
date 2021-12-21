using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day21Tests {
	private const string TestInput = @"Player 1 starting position: 4
Player 2 starting position: 8";

	[Theory]
	[InlineData(TestInput, 739785)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day21 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	[Theory]
	[InlineData(TestInput, 444356092776315L)]
	public void PartTwoSucceeds(string input, long expectedResult) {
		Day21 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
