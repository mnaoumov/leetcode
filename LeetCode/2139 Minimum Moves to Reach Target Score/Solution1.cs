using JetBrains.Annotations;

namespace LeetCode._2139_Minimum_Moves_to_Reach_Target_Score;

/// <summary>
/// https://leetcode.com/submissions/detail/914110109/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMoves(int target, int maxDoubles)
    {
        var result = 0;

        while (target > 1)
        {
            if (maxDoubles == 0)
            {
                result += target - 1;
                break;
            }

            if (target % 2 == 1)
            {
                target--;
            }
            else
            {
                target /= 2;
                maxDoubles--;
            }

            result++;
        }

        return result;
    }
}
