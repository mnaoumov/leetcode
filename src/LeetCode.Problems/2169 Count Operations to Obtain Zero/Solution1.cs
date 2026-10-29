namespace LeetCode.Problems._2169_Count_Operations_to_Obtain_Zero;

/// <summary>
/// https://leetcode.com/problems/count-operations-to-obtain-zero/submissions/1824605476/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountOperations(int num1, int num2)
    {
        var ans = 0;

        while (num1 > 0 && num2 > 0)
        {
            ans++;
            if (num1 >= num2)
            {
                num1 -= num2;
            }
            else
            {
                num2 -= num1;
            }
        }

        return ans;
    }
}
