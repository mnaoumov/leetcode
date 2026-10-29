namespace LeetCode.Problems._1111_Maximum_Nesting_Depth_of_Two_Valid_Parentheses_Strings;

/// <summary>
/// https://leetcode.com/problems/maximum-nesting-depth-of-two-valid-parentheses-strings/submissions/2157643059/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MaxDepthAfterSplit(string seq)
    {
        var n = seq.Length;
        var ans = new int[n];

        var depth = 0;

        for (var i = 0; i < n; i++)
        {
            if (seq[i] == '(')
            {
                ans[i] = depth % 2;
                depth++;
            }
            else
            {
                depth--;
                ans[i] = depth % 2;
            }
        }

        return ans;
    }
}
