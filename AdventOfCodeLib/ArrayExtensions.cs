namespace AdventOfCodeLib;

internal static class ArrayExtensions {
	public static void Deconstruct<T>(this T[] arr, out T a0, out T a1) {
		if (arr == null || arr.Length != 2) throw new ArgumentException("Array deconstructed but not of size 2", nameof(arr));
		a0 = arr[0];
		a1 = arr[1];
	}
}
