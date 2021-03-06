using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day18Tests {
	private const string TestInput = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

	[Theory]
	[InlineData("[[1,2],[[3,4],5]]", 143)]
	[InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
	[InlineData("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
	[InlineData("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
	[InlineData("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
	[InlineData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
	[InlineData(TestInput, 4140)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day18 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	[Theory]
	[InlineData("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
	[InlineData("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
	[InlineData("[[6,[5,[4,[3,2]]]],1]", "[[6,[5,[7,0]]],3]")]
	[InlineData("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
	[InlineData("[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]", "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
	public void ReduceSucceeds(string input, string expectedResult) {
		Day18 challenge = new();
		Assert.Equal(expectedResult, challenge.Reduce(input));
	}

	[Theory]
	[InlineData(TestInput, 3993)]
	public void PartTwoSucceeds(string input, int expectedResult) {
		Day18 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
