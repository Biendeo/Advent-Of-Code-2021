using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day05Tests {
	private const string TestInput = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

	[Theory]
	[InlineData(TestInput, 5)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day05 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	[Theory]
	[InlineData(TestInput, 12)]
	public void PartTwoSucceeds(string input, int expectedResult) {
		Day05 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
