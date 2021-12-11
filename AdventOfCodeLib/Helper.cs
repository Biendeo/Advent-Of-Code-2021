namespace AdventOfCodeLib {
	internal static class Helper {
		internal static IEnumerable<(int x, int y)> GetTwoDimensionalRange(int startX, int endX, int startY, int endY) => Enumerable.Range(startX, endX - startX + 1).SelectMany(x => Enumerable.Range(startY, endY - startY + 1).Select(y => (x, y)));

		internal static IEnumerable<(int x, int y)> GetNeighbors(int x, int y, int minX, int maxX, int minY, int maxY, bool diagonals) {
			if (diagonals && x > minX && y > minY) yield return (x - 1, y - 1);
			if (y > minY) yield return (x, y - 1);
			if (diagonals && x < maxX && y > minY) yield return (x + 1, y - 1);
			if (x > minX) yield return (x - 1, y);
			if (x < maxX) yield return (x + 1, y);
			if (diagonals && x > minX && y < maxY) yield return (x - 1, y + 1);
			if (y < maxY) yield return (x, y + 1);
			if (diagonals && x < maxX && y < maxY) yield return (x + 1, y + 1);
		}
	}
}
