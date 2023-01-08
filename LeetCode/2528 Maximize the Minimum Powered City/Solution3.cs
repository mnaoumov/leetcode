using JetBrains.Annotations;

namespace LeetCode._2528_Maximize_the_Minimum_Powered_City;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
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
            var smallPowersMap = new SortedList<int, long>();

            for (var i = 0; i < powers.Length; i++)
            {
                var power = powers[i];

                if (power < desiredMinPower)
                {
                    smallPowersMap[i] = power;
                }
            }

            var potentialPowers = powers.ToArray();
            long newStationsAvailableCount = k;

            var updates = new Queue<(int updateIndex, int addedStationsCount)>();

            foreach (var (index, power) in smallPowersMap)
            {
                var stationsNeededCount = desiredMinPower - power;

                foreach (var (updateIndex, addedStationsCount) in updates.ToArray())
                {
                    if (updateIndex + r < index)
                    {
                        updates.Dequeue();
                    }
                    else
                    {
                        stationsNeededCount -= addedStationsCount;

                        if (stationsNeededCount <= 0)
                        {
                            break;
                        }
                    }
                }

                if (stationsNeededCount <= 0)
                {
                    continue;
                }

                if (stationsNeededCount > newStationsAvailableCount)
                {
                    return false;
                }

                //updates.Enqueue((index, stationsNeededCount));
                //newStationsAvailableCount
            }


            for (var i = 0; i < potentialPowers.Length; i++)
            {
                var potentialPower = potentialPowers[i];

                if (potentialPower >= desiredMinPower)
                {
                    continue;
                }

                var stationsNeededCount = desiredMinPower - potentialPower;

                if (stationsNeededCount > newStationsAvailableCount)
                {
                    return false;
                }

                newStationsAvailableCount -= stationsNeededCount;

                for (var j = i; j <= Math.Min(i + 2 * r, n - 1); j++)
                {
                    potentialPowers[j] += stationsNeededCount;
                }
            }

            return true;
        }
    }
}
