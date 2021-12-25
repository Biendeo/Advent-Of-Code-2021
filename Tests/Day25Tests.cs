using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day25Tests {
	private const string TestInput = @"v...>>.vv>
.vv>>.vv..
>>.>v>...v
>>v>>.>.v.
v>v.vv.v..
>.>>..v...
.vv..>.>v.
v.v..>>v.v
....v..v.>";

	[Theory]
	[InlineData(TestInput, 58)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day25 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}
}
