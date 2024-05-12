using JetBrains.Annotations;

namespace LeetCode._1342_Number_of_Steps_to_Reduce_a_Number_to_Zero;

/// <summary>
/// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/submissions/845591907/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSteps(int num)
    {
        var result = 0;

        while (num != 0)
        {
            if (num % 2 == 0)
            {
                num /= 2;
            }
            else
            {
                num--;
            }

            result++;
        }

        return result;
    }
}
