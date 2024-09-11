using JetBrains.Annotations;

namespace LeetCode.Problems._3258_Count_Substrings_That_Satisfy_K_Constraint_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-411/submissions/detail/1359745532/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountKConstraintSubstrings(string s, int k)
    {
        var n = s.Length;
        var zeroCounts = new int[n + 1];
        var oneCounts = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            zeroCounts[i + 1] = zeroCounts[i] + (s[i] == '0' ? 1 : 0);
            oneCounts[i + 1] = oneCounts[i] + (s[i] == '1' ? 1 : 0);
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var j1 = BinarySearchFirst(zeroCounts, i + 1, zeroCounts[i] + k + 1);
            var j2 = BinarySearchFirst(oneCounts, i + 1, oneCounts[i] + k + 1);
            ans += Math.Max(j1, j2) - i - 1;
        }


        return ans;
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
}
