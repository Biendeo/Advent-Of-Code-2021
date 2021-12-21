using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day20Tests {
	private const string TestInput = @"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###";

	[Theory]
	[InlineData(TestInput, 35)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day20 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	[Theory]
	[InlineData(TestInput, 3351)]
	public void PartTwoSucceeds(string input, int expectedResult) {
		Day20 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
