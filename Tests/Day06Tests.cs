using AdventOfCodeLib.Challenges;
using System.Linq;
using Xunit;

namespace Tests;

public class Day06Tests {
	[Theory]
	[InlineData(new int[] { 3, 4, 3, 1, 2 }, 18, 26)]
	[InlineData(new int[] { 3, 4, 3, 1, 2 }, 80, 5934)]
	[InlineData(new int[] { 3, 4, 3, 1, 2 }, 256, 26984457539L)]
	public void SolveSucceeds(int[] input, int days, long expectedResult) {
		Day06 challenge = new();
		Assert.Equal(expectedResult, challenge.Solve(input.ToList(), days));
	}
}
