using JetBrains.Annotations;

namespace LeetCode._1552_Magnetic_Force_Between_Two_Balls;

/// <summary>
/// https://leetcode.com/submissions/detail/931585678/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);

        var low = 1;
        var high = (position[^1] - position[0]) / (m - 1);

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanDistribute(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool CanDistribute(int force)
        {
            var ballsLeft = m - 1;

            var i = 0;

            while (true)
            {
                var j = Array.BinarySearch(position, position[i] + force);

                if (j < 0)
                {
                    j = ~j;
                }

                if (j == position.Length)
                {
                    return false;
                }

                ballsLeft--;

                if (ballsLeft == 0)
                {
                    return true;
                }

                i = j;
            }
        }
    }
}
