namespace LeetCode.Problems._3086_Minimum_Moves_to_Pick_K_Ones;

/// <summary>
/// NotImplemented
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution8 : ISolution
{
    public long MinimumMoves(int[] nums, int k, int maxChanges)
    {
        var n = nums.Length;

        var oneIndices = Enumerable.Range(0, n).Where(i => nums[i] == 1).ToArray();

        var ans = long.MaxValue;

        var dylanIndices = new HashSet<int>();

        const int impossible = -1;

        switch (oneIndices.Length)
        {
            case 0:
                dylanIndices.Add(0);
                break;
            case 1:
                dylanIndices.Add(oneIndices[0]);
                break;
            default:
                var median1 = oneIndices[oneIndices.Length / 2 - 1];
                var median2 = oneIndices[oneIndices.Length / 2];

                dylanIndices.Add(median1);
                dylanIndices.Add(median2);

                var maxPairIndex = oneIndices
                    .Where(index => index < median1 && index > 0 && nums[index - 1] == 1)
                    .DefaultIfEmpty(impossible).Max();

                if (maxPairIndex != impossible)
                {
                    dylanIndices.Add(maxPairIndex);
                }

                var minPairIndex = oneIndices
                    .Where(index => index > median2 && index < n - 1 && nums[index + 1] == 1)
                    .DefaultIfEmpty(impossible).Max();

                if (minPairIndex != impossible)
                {
                    dylanIndices.Add(minPairIndex);
                }

                var maxTripletIndex = oneIndices
                    .Where(index => index < median1 && index > 0 && nums[index - 1] == 1 && index < n - 1 && nums[index + 1] == 1)
                    .DefaultIfEmpty(impossible).Max();

                if (maxTripletIndex != impossible)
                {
                    dylanIndices.Add(maxTripletIndex);
                }

                var minTripletIndex = oneIndices
                    .Where(index => index > median2 && nums[index - 1] == 1 && index < n - 1 && nums[index + 1] == 1)
                    .DefaultIfEmpty(impossible).Max();

                if (minTripletIndex != impossible)
                {
                    dylanIndices.Add(minTripletIndex);
                }

                break;
        }

        foreach (var dylanIndex in dylanIndices)
        {
            var onesLeft = k;

            var movesCount = 0L;

            if (nums[dylanIndex] == 1)
            {
                onesLeft--;
            }

            if (onesLeft == 0)
            {
                return 0;
            }

            if (dylanIndex > 0 && nums[dylanIndex - 1] == 1)
            {
                movesCount++;
                onesLeft--;
            }

            if (onesLeft == 0)
            {
                ans = Math.Min(ans, movesCount);
                continue;
            }

            if (dylanIndex < n - 1 && nums[dylanIndex + 1] == 1)
            {
                movesCount++;
                onesLeft--;
            }

            if (onesLeft == 0)
            {
                ans = Math.Min(ans, movesCount);
                continue;
            }

            var changesCount = Math.Min(maxChanges, onesLeft);
            movesCount += 1L * changesCount * 2;
            onesLeft -= changesCount;

            if (onesLeft == 0)
            {
                ans = Math.Min(ans, movesCount);
                continue;
            }

            foreach (var swapsCount in oneIndices.Select(index => Math.Abs(index - dylanIndex)).OrderBy(swapsCount => swapsCount).Where(swapsCount => swapsCount >= 2))
            {
                movesCount += swapsCount;
                onesLeft--;

                if (onesLeft != 0)
                {
                    continue;
                }

                ans = Math.Min(ans, movesCount);
                break;
            }
        }

        return ans;
    }
}
