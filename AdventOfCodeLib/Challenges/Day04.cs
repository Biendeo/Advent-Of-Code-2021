namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 4, Name = "Giant Squid")]
public class Day04 : IDayChallenge {
	private const int CheckedValue = -1;
	private const int BoardSize = 5;

	public string PartOneFromFile(string[] inputLines) {
		(int[] drawnNumbers, List<int[,]> bingoBoards) = ParseInput(inputLines);
		return PartOne(drawnNumbers, bingoBoards).ToString();
	}

	public int PartOne(int[] drawnNumbers, List<int[,]> bingoBoards) => bingoBoards.Select(b => GetVictoryOfBoard(drawnNumbers, b)).Aggregate((a, b) => a.turnCount < b.turnCount ? a : b).score;

	public string PartTwoFromFile(string[] inputLines) {
		(int[] drawnNumbers, List<int[,]> bingoBoards) = ParseInput(inputLines);
		return PartTwo(drawnNumbers, bingoBoards).ToString();
	}

	public int PartTwo(int[] drawnNumbers, List<int[,]> bingoBoards) => bingoBoards.Select(b => GetVictoryOfBoard(drawnNumbers, b)).Aggregate((a, b) => a.turnCount > b.turnCount ? a : b).score;

	public static (int[] drawnNumbers, List<int[,]> bingoBoards) ParseInput(string[] input) {
		List<int[,]> bingoBoards = new();
		for (int inputY = 1; inputY < input.Length; inputY += 6) {
			int[,] board = new int[BoardSize, BoardSize];
			for (int y = 0; y < BoardSize; ++y) {
				int[] parsedRow = input[inputY + y + 1].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(x => int.Parse(x)).ToArray();
				for (int x = 0; x < BoardSize; ++x) {
					board[x, y] = parsedRow[x];
				}
			}
			bingoBoards.Add(board);
		}
		return (input[0].Split(',').Select(x => int.Parse(x)).ToArray(), bingoBoards);
	}

	private (int turnCount, int score) GetVictoryOfBoard(int[] drawnNumbers, int[,] bingoBoard) {
		int[,] modifiedBoard = (int[,])bingoBoard.Clone();
		int lastDrawnNumber = -1;
		int turnCount;
		for (turnCount = 0; turnCount < drawnNumbers.Length && !DoesBoardHaveVictory(modifiedBoard); ++turnCount) {
			lastDrawnNumber = drawnNumbers[turnCount];
			for (int x = 0; x < BoardSize; ++x) {
				for (int y = 0; y < BoardSize; ++y) {
					if (modifiedBoard[x, y] == lastDrawnNumber) {
						modifiedBoard[x, y] = CheckedValue;
					}
				}
			}
		}
		return (turnCount, GetBoardScore(modifiedBoard, lastDrawnNumber));
	}

	private bool DoesBoardHaveVictory(int[,] bingoBoard) {
		// Horizontal
		for (int y = 0; y < BoardSize; ++y) {
			int sum = 0;
			for (int x = 0; x < BoardSize; ++x) {
				sum += bingoBoard[x, y];
			}
			if (sum == CheckedValue * BoardSize) {
				return true;
			}
		}

		// Vertical
		for (int x = 0; x < BoardSize; ++x) {
			int sum = 0;
			for (int y = 0; y < BoardSize; ++y) {
				sum += bingoBoard[x, y];
			}
			if (sum == CheckedValue * BoardSize) {
				return true;
			}
		}

		return false;
	}
	
	private int GetBoardScore(int[,] bingoBoard, int lastDrawnNumber) {
		int score = 0;
		for (int x = 0; x < BoardSize; ++x) {
			for (int y = 0; y < BoardSize; ++y) {
				if (bingoBoard[x, y] != CheckedValue) {
					score += bingoBoard[x, y];
				}
			}
		}
		return score * lastDrawnNumber;
	}
}