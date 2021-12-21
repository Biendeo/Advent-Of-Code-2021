namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 21, Name = "Dirac Dice")]
public class Day21 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) {
		int p1Space = int.Parse(inputLines[0][28..]), p2Space = int.Parse(inputLines[1][28..]), p1Score = 0, p2Score = 0;
		bool p1Turn = true;
		int numRolls = 0;
		while (p1Score < 1000 && p2Score < 1000) {
			int roll = 0;
			for (int i = 0; i < 3; ++i) {
				roll += (numRolls++ % 100) + 1;
			}
			if (p1Turn) {
				p1Space = (p1Space + roll - 1) % 10 + 1;
				p1Score += p1Space;
			} else {
				p2Space = (p2Space + roll - 1) % 10 + 1;
				p2Score += p2Space;
			}
			p1Turn = !p1Turn;
		}
		return Math.Min(p1Score, p2Score) * numRolls;
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public long PartTwo(string[] inputLines) {
		int p1StartSpace = int.Parse(inputLines[0][28..]), p2StartSpace = int.Parse(inputLines[1][28..]);
		(long p1Wins, long p2Wins) = ComputeWinningStates(true, p1StartSpace, p2StartSpace, 0, 0);
		return Math.Max(p1Wins, p2Wins);
	}

	private (long p1Wins, long p2Wins) ComputeWinningStates(bool p1Turn, int p1Space, int p2Space, int p1Score, int p2Score) {
		if (p1Score >= 21 && p2Score < 21) {
			return (1L, 0L);
		} else if (p1Score < 21 && p2Score >= 21) {
			return (0L, 1L);
		} else if (p1Score >= 21 && p2Score >= 21) {
			return (0L, 0L);
		} else {
			(int, int)[] diceRollFrequencies = new[] { (3, 1), (4, 3), (5, 6), (6, 7), (7, 6), (8, 3), (9, 1) };
			long p1Wins = 0L, p2Wins = 0L;
			if (p1Turn) {
				foreach ((int roll, int frequency) in diceRollFrequencies) {
					int newSpace = (p1Space + roll - 1) % 10 + 1;
					(long newP1Wins, long newP2Wins) = ComputeWinningStates(!p1Turn, newSpace, p2Space, p1Score + newSpace, p2Score);
					p1Wins += newP1Wins * frequency;
					p2Wins += newP2Wins * frequency;
				}
			} else {
				foreach ((int roll, int frequency) in diceRollFrequencies) {
					int newSpace = (p2Space + roll - 1) % 10 + 1;
					(long newP1Wins, long newP2Wins) = ComputeWinningStates(!p1Turn, p1Space, newSpace, p1Score, p2Score + newSpace);
					p1Wins += newP1Wins * frequency;
					p2Wins += newP2Wins * frequency;
				}
			}
			return (p1Wins, p2Wins);
		}
	}
}
