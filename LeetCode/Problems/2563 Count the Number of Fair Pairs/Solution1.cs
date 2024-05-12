using JetBrains.Annotations;

namespace LeetCode.Problems._2563_Count_the_Number_of_Fair_Pairs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-332/submissions/detail/896293379/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        var list = new List<int>();
        var result = 0L;

        foreach (var num in nums)
        {
            result += CountItemsInRange(lower - num, upper - num);

            var insertIndex = list.BinarySearch(num);

            if (insertIndex < 0)
            {
                insertIndex = ~insertIndex;
            }
            list.Insert(insertIndex, num);
        }

        return result;

        long CountItemsInRange(int a, int b)
        {
            var indexLeft = list.BinarySearch(a);

            if (indexLeft < 0)
            {
                indexLeft = ~indexLeft;
            }
            else
            {
                while (indexLeft > 0 && list[indexLeft - 1] == a)
                {
                    indexLeft--;
                }
            }

            var indexRight = list.BinarySearch(b);

            if (indexRight < 0)
            {
                indexRight = ~indexRight - 1;
            }
            else
            {
                while (indexRight < list.Count - 1 && list[indexRight + 1] == b)
                {
                    indexRight++;
                }
            }

            if (indexLeft <= indexRight && indexLeft < list.Count)
            {
                return indexRight - indexLeft + 1;
            }

            return 0;
        }
    }
}
