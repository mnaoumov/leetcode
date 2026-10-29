namespace LeetCode.Problems._2528_Maximize_the_Minimum_Powered_City;

/// <summary>
/// https://leetcode.com/submissions/detail/874344806/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
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

            long newStationsAvailableCount = k;

            var updates = new Queue<(int updateIndex, long addedStationsCount)>();

            foreach (var (index, power) in smallPowersMap)
            {
                var stationsNeededCount = desiredMinPower - power;

                if (stationsNeededCount <= 0)
                {
                    continue;
                }

                while (updates.Count > 0)
                {
                    var (updateIndex, addedStationsCount) = updates.Peek();

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

                updates.Enqueue((Math.Min(index + r, n - 1), stationsNeededCount));
                newStationsAvailableCount -= stationsNeededCount;
            }

            return true;
        }
    }
}
