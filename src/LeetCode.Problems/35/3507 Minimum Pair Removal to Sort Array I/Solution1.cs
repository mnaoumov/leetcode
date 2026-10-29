namespace LeetCode.Problems._3507_Minimum_Pair_Removal_to_Sort_Array_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-444/problems/minimum-pair-removal-to-sort-array-i/submissions/1597997027/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumPairRemoval(int[] nums)
    {
        var list = nums.ToList();
        var ans = 0;

        while (true)
        {
            var minPairSum = int.MaxValue;
            var minPairIndex = -1;
            var isSorted = true;

            for (var i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    isSorted = false;
                }

                var pairSum = list[i] + list[i + 1];
                if (pairSum >= minPairSum)
                {
                    continue;
                }

                minPairSum = pairSum;
                minPairIndex = i;
            }

            if (isSorted)
            {
                return ans;
            }

            list.RemoveRange(minPairIndex, 2);
            list.Insert(minPairIndex, minPairSum);
            ans++;
        }
    }
}
