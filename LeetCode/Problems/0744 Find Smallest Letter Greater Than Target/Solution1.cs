using JetBrains.Annotations;

namespace LeetCode.Problems._0744_Find_Smallest_Letter_Greater_Than_Target;

/// <summary>
/// https://leetcode.com/submissions/detail/925459162/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        var low = 0;
        var high = letters.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (letters[mid] <= target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low == letters.Length ? letters[0] : letters[low];
    }
}
