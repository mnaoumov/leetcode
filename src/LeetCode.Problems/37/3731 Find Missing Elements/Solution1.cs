namespace LeetCode.Problems._3731_Find_Missing_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-474/problems/find-missing-elements/submissions/1818196634/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindMissingElements(int[] nums)
    {
        var ans = new List<int>();
        var min = nums.Min();
        var max = nums.Max();
        var set = nums.ToHashSet();

        for (var i = min + 1; i < max; i++)
        {
            if (!set.Contains(i))
            {
                ans.Add(i);
            }
        }

        return ans;
    }
}
