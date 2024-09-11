using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2604_Minimum_Time_to_Eat_All_Grains;

/// <summary>
/// https://leetcode.com/submissions/detail/924619355/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution5 : ISolution
{
    public int MinimumTime(int[] hens, int[] grains)
    {
        Array.Sort(hens);
        Array.Sort(grains);

        var low = 0;
        var high = 1_000_000_000;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanEat(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanEat(int time)
        {
            var maxHenPosition = int.MinValue;
            var minHenIndex = 0;

            foreach (var grain in grains)
            {
                if (grain <= maxHenPosition)
                {
                    continue;
                }

                var low2 = minHenIndex;
                var high2 = hens.Length - 1;

                while (low2 <= high2)
                {
                    var mid = low2 + (high2 - low2 >> 1);

                    if (hens[mid] < grain - time)
                    {
                        low2 = mid + 1;
                    }
                    else
                    {
                        high2 = mid - 1;
                    }
                }

                var henIndex = low2;

                if (henIndex == hens.Length)
                {
                    return false;
                }

                var hen = hens[henIndex];
                var usedTime = Math.Abs(hen - grain);
                var spareTime = time - usedTime;

                if (spareTime < 0)
                {
                    return false;
                }

                maxHenPosition = hen <= grain ? grain + spareTime : hen + spareTime / 2;
                minHenIndex = henIndex + 1;
            }

            return true;
        }
    }
}
