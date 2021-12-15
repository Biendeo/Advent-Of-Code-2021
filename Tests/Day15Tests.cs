using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day15Tests {
	private const string TestInput = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";

	[Theory]
	[InlineData(TestInput, 40)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day15 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	[Theory]
	[InlineData(TestInput, 315)]
	public void PartTwoSucceeds(string input, int expectedResult) {
		Day15 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
