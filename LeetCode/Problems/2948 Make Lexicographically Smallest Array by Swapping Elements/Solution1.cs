using JetBrains.Annotations;

namespace LeetCode._2948_Make_Lexicographically_Smallest_Array_by_Swapping_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-373/submissions/detail/1106479624/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        var n = nums.Length;
        var indicesSortedByNum = Enumerable.Range(0, n).OrderBy(i => nums[i]).ThenBy(i => i).ToArray();
        var indexGroups = new List<List<int>>();

        foreach (var index in indicesSortedByNum)
        {
            if (indexGroups.Count == 0 || nums[index] > nums[indexGroups[^1][^1]] + limit)
            {
                indexGroups.Add(new List<int>());
            }

            indexGroups[^1].Add(index);
        }

        var ans = new int[n];

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var indexGroup in indexGroups)
        {
            var sortedIndexGroup = indexGroup.OrderBy(i => i);
            var indexPairs = sortedIndexGroup.Zip(indexGroup, (sortedIndex, originalIndex) => (sortedIndex, originalIndex));

            foreach (var (sortedIndex, originalIndex) in indexPairs)
            {
                ans[sortedIndex] = nums[originalIndex];
            }
        }

        return ans;
    }
}
