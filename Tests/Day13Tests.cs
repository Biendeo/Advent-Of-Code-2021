using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day13Tests {
	public const string TestInput = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

	[Theory]
	[InlineData(TestInput, 17)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day13 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	public const string ExpectedPartTwo = @"#####
#   #
#   #
#   #
#####";

	[Theory]
	[InlineData(TestInput, ExpectedPartTwo)]
	public void PartTwoSucceeds(string input, string expectedResult) {
		Day13 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
