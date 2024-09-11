using JetBrains.Annotations;

namespace LeetCode.Problems._3261_Count_Substrings_That_Satisfy_K_Constraint_II;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long[] CountKConstraintSubstrings(string s, int k, int[][] queries)
    {
        var n = s.Length;
        var zeroCounts = new int[n + 1];
        var oneCounts = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            zeroCounts[i + 1] = zeroCounts[i] + (s[i] == '0' ? 1 : 0);
            oneCounts[i + 1] = oneCounts[i] + (s[i] == '1' ? 1 : 0);
        }

        var kConstraintCountsByStart = new int[n];

        for (var i = 0; i < n; i++)
        {
            var j1 = BinarySearchFirst(zeroCounts, i + 1, zeroCounts[i] + k + 1);
            var j2 = BinarySearchFirst(oneCounts, i + 1, oneCounts[i] + k + 1);
            kConstraintCountsByStart[i] = Math.Max(j1, j2) - i - 1;
        }

        var kConstraintCountsByStartAfter = new long[n];
        kConstraintCountsByStartAfter[n - 1] = kConstraintCountsByStart[n - 1];

        for (var i = n - 2; i >= 0; i--)
        {
            kConstraintCountsByStartAfter[i] = kConstraintCountsByStartAfter[i + 1] + kConstraintCountsByStart[i];
        }

        var kConstraintCountsByEnd = new int[n];

        for (var i = n - 1; i >= 0; i--)
        {
            var j1 = BinarySearchLast(zeroCounts, 0, zeroCounts[i] - k - 1);
            var j2 = BinarySearchFirst(oneCounts, 0, oneCounts[i] - k - 1);
            kConstraintCountsByEnd[i] = i - Math.Min(j1, j2) + 1;
        }

        var kConstraintCountsByEndBefore = new long[n];
        kConstraintCountsByEndBefore[0] = kConstraintCountsByEnd[0];

        for (var i = 1; i < n; i++)
        {
            kConstraintCountsByEndBefore[i] = kConstraintCountsByEndBefore[i - 1] + kConstraintCountsByEnd[i];
        }

        return queries.Select(Answer).ToArray();

        long Answer(int[] query)
        {
            var l = query[0];
            return kConstraintCountsByStartAfter[l];
        }
    }

    private static int BinarySearchFirst<T>(IReadOnlyList<T> arr, int firstIndex, T value) where T : IComparable<T>
    {
        var low = firstIndex;
        var high = arr.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (arr[mid].CompareTo(value) >= 0)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    private static int BinarySearchLast<T>(IReadOnlyList<T> arr, int firstIndex, T value) where T : IComparable<T>
    {
        var low = firstIndex;
        var high = arr.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (arr[mid].CompareTo(value) > 0)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return high;
    }
}
