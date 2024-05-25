using JetBrains.Annotations;

namespace LeetCode.Problems._3159_Find_Occurrences_of_an_Element_in_an_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-131/submissions/detail/1267537397/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] OccurrencesOfElement(int[] nums, int[] queries, int x)
    {
        var indices = new List<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == x)
            {
                indices.Add(i);
            }
        }

        return queries.Select(query => query <= indices.Count ? indices[query - 1] : -1).ToArray();
    }
}
