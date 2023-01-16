using JetBrains.Annotations;

namespace LeetCode._1533_Find_the_Index_of_the_Large_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/878929474/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetIndex(ArrayReader reader)
    {
        var left = 0;
        var right = reader.Length() - 1;

        while (true)
        {
            var mid = left + (right - left >> 1);
            var length = right - left + 1;

            if (length == 1)
            {
                return left;
            }

            var skippedIndex = left;
            left += length % 2;

            var comparisonResult = reader.CompareSub(left, mid, mid + 1, right);

            switch (comparisonResult)
            {
                case 0:
                    return skippedIndex;
                case -1:
                    left = mid + 1;
                    break;
                case 1:
                    right = mid;
                    break;
            }
        }
    }
}
