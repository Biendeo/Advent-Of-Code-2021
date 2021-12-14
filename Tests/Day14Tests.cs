using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day14Tests {
	private const string TestInput = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

	[Theory]
	[InlineData(TestInput, 1588L)]
	public void PartOneSucceeds(string input, long expectedResult) {
		Day14 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	[Theory]
	[InlineData(TestInput, 2188189693529L)]
	public void PartTwoSucceeds(string input, long expectedResult) {
		Day14 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
