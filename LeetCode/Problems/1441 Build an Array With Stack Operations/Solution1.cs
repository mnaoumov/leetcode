namespace LeetCode.Problems._1441_Build_an_Array_With_Stack_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/1090669303/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<string> BuildArray(int[] target, int n)
    {
        var set = target.ToHashSet();

        var ans = new List<string>();

        for (var i = 1; i <= n; i++)
        {
            ans.Add("Push");

            if (!set.Contains(i))
            {
                ans.Add("Pop");
            }
        }

        return ans;
    }
}
