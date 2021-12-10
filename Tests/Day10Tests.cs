using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day10Tests {
	private const string TestInput = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

	[Theory]
	[InlineData(TestInput, 26397)]
	public void PartOneSucceeds(string input, long expectedResult) {
		Day10 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	[Theory]
	[InlineData(TestInput, 288957)]
	public void PartTwoSucceeds(string input, long expectedResult) {
		Day10 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
