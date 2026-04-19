namespace LeetCode.Problems._1320_Minimum_Distance_to_Type_a_Word_Using_Two_Fingers;

/// <summary>
/// https://leetcode.com/problems/minimum-distance-to-type-a-word-using-two-fingers/submissions/1975887369/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDistance(string word)
    {
        var dp = new DynamicProgramming<(int letterIndex, char lastLetterFinger1, char lastLetterFinger2), int>((key, getOrCalculate) =>
        {
            var (letterIndex, lastLetterFinger1, lastLetterFinger2) = key;

            if (letterIndex == word.Length)
            {
                return 0;
            }

            var letter = word[letterIndex];

            var ans2 = DistanceBetween(lastLetterFinger1, letter) + getOrCalculate((letterIndex+1,letter,lastLetterFinger2));

            ans2 = Math.Min(ans2,
                DistanceBetween(lastLetterFinger2, letter) +
                getOrCalculate((letterIndex + 1, lastLetterFinger1, letter)));

            return ans2;
        });

        var ans = int.MaxValue;

        for (var initialLetterFinger1 = 'A'; initialLetterFinger1 <= 'Z'; initialLetterFinger1++)
        {
            for (var initialLetterFinger2 = (char) (initialLetterFinger1 + 1); initialLetterFinger2 <= 'Z'; initialLetterFinger2++)
            {
                ans = Math.Min(ans, dp.GetOrCalculate((0, initialLetterFinger1, initialLetterFinger2)));
            }
        }

        return ans;
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

    private static int DistanceBetween(char letter1, char letter2) => Coordinate.OfLetter(letter1).DistanceTo(Coordinate.OfLetter(letter2));

    private sealed record Coordinate(int RowIndex, int ColumnIndex)
    {
        public int DistanceTo(Coordinate coordinate) => Math.Abs(coordinate.RowIndex - RowIndex) + Math.Abs(coordinate.ColumnIndex - ColumnIndex);

        public static Coordinate OfLetter(char letter)
        {
            var offset = letter - 'A';
            const int lettersPerRowCount = 6;
            var rowIndex = offset / lettersPerRowCount;
            var columnIndex = offset % lettersPerRowCount;
            return new Coordinate(rowIndex, columnIndex);
        }
    }
}
