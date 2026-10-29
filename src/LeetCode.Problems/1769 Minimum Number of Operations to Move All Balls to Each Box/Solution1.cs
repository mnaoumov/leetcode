namespace LeetCode.Problems._1769_Minimum_Number_of_Operations_to_Move_All_Balls_to_Each_Box;

/// <summary>
/// https://leetcode.com/submissions/detail/1500084877/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MinOperations(string boxes)
    {
        var n = boxes.Length;
        var ans = new int[n];
        for (var i = 0; i < n; i++)
        {
            if (boxes[i] != '1')
            {
                continue;
            }

            for (var j = 0; j < n; j++)
            {
                ans[j] += Math.Abs(i - j);
            }
        }

        return ans;
    }
}
