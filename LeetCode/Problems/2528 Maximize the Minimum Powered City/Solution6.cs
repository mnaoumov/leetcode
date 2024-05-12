using JetBrains.Annotations;

namespace LeetCode.Problems._2528_Maximize_the_Minimum_Powered_City;

/// <summary>
/// https://leetcode.com/submissions/detail/874354632/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public long MaxPower(int[] stations, int r, int k)
    {
        var n = stations.Length;
        var powers = new long[n];

        powers[0] = stations.Take(r + 1).Sum(s => (long) s);

        var minPower = powers[0];

        for (var i = 1; i < n; i++)
        {
            powers[i] = powers[i - 1] + (i + r < n ? stations[i + r] : 0) - (i - 1 - r >= 0 ? stations[i - 1 - r] : 0);
            minPower = Math.Min(minPower, powers[i]);
        }

        var maxPower = (powers.Sum() + 1L * (2 * r + 1) * k) / n;

        while (minPower <= maxPower)
        {
            var midPower = minPower + (maxPower - minPower >> 1);

            if (CanGetMinPower(midPower))
            {
                if (midPower == minPower)
                {
                    if (maxPower == minPower + 1 && CanGetMinPower(maxPower))
                    {
                        minPower++;
                    }

                    break;
                }

                minPower = midPower;
            }
            else
            {
                maxPower = midPower - 1;
            }
        }

        return minPower;

        bool CanGetMinPower(long desiredMinPower)
        {
            long newStationsAvailableCount = k;
            long extraPower = 0;
            var extraPowerEffectEndedMap = new Dictionary<int, long>();

            for (var i = 0; i < n; i++)
            {
                if (extraPowerEffectEndedMap.TryGetValue(i, out var value))
                {
                    extraPower -= value;
                }

                var power = powers[i] + extraPower;

                if (power >= desiredMinPower)
                {
                    continue;
                }

                var stationsCountNeeded = desiredMinPower - power;

                if (stationsCountNeeded > newStationsAvailableCount)
                {
                    return false;
                }

                newStationsAvailableCount -= stationsCountNeeded;
                extraPower += stationsCountNeeded;
                extraPowerEffectEndedMap[i + 2 * r + 1] = stationsCountNeeded;
            }

            return true;
        }
    }
}
