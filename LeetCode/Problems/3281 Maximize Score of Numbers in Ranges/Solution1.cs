using JetBrains.Annotations;

namespace LeetCode.Problems._3281_Maximize_Score_of_Numbers_in_Ranges;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-414/submissions/detail/1382689217/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxPossibleScore(int[] start, int d)
    {
        Array.Sort(start);
        var n = start.Length;
        var minLength = Enumerable.Range(0, n - 1).Select(i => start[i + 1] - start[i]).Min();

        var low = minLength;
        var high = minLength + d;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanMakeScore(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool CanMakeScore(int score)
        {
            var value = start[0];

            for (var i = 1; i < n; i++)
            {
                value = Math.Max(start[i], value + score);

                if (value > start[i] + d)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
