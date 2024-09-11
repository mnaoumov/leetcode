namespace LeetCode.Problems._1898_Maximum_Number_of_Removable_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/933438422/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumRemovals(string s, string p, int[] removable)
    {
        var low = 0;
        var high = removable.Length;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanFormSubsequence(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool CanFormSubsequence(int k)
        {
            var removedIndices = removable.Take(k).ToHashSet();

            var i = 0;
            var j = 0;

            while (i < s.Length)
            {
                if (!removedIndices.Contains(i) && s[i] == p[j])
                {
                    j++;

                    if (j == p.Length)
                    {
                        return true;
                    }
                }

                i++;
            }

            return false;
        }
    }
}
