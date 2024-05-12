using JetBrains.Annotations;

namespace LeetCode.Problems._3002_Maximum_Size_of_a_Set_After_Removals;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-379/submissions/detail/1139146908/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumSetSize(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;
        var m = n / 2;
        var set1 = nums1.ToHashSet();
        var set2 = nums2.ToHashSet();

        var commonCount = set1.Intersect(set2).Count();
        var onlySet1Count = Math.Min(set1.Count - commonCount, m);
        var onlySet2Count = Math.Min(set2.Count - commonCount, m);

        var removedCount1 = nums1.Length - onlySet1Count - commonCount;
        var removedCount2 = nums2.Length - onlySet2Count - commonCount;

        if (removedCount1 < m)
        {
            var remove1 = Math.Min(m - removedCount1, commonCount);
            commonCount -= remove1;
            onlySet2Count += remove1;
            removedCount1 += remove1;

            if (removedCount1 < m)
            {
                remove1 = m - removedCount1;
                onlySet1Count -= remove1;
            }
        }

        // ReSharper disable once InvertIf
        if (removedCount2 < m)
        {
            var remove2 = Math.Min(m - removedCount2, commonCount);
            commonCount -= remove2;
            onlySet1Count += remove2;
            removedCount2 += remove2;

            // ReSharper disable once InvertIf
            if (removedCount2 < m)
            {
                remove2 = m - removedCount2;
                onlySet2Count -= remove2;
            }
        }

        return onlySet1Count + onlySet2Count + commonCount;
    }
}
