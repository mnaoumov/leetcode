using JetBrains.Annotations;

namespace LeetCode._3086_Minimum_Moves_to_Pick_K_Ones;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-389/submissions/detail/1205955098/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution3 : ISolution
{
    public long MinimumMoves(int[] nums, int k, int maxChanges)
    {
        var n = nums.Length;

        var oneIndices = Enumerable.Range(0, n).Where(i => nums[i] == 1).ToArray();

        var ans = long.MaxValue;

        var dylanIndices = new List<int>();

        switch (oneIndices.Length)
        {
            case 0:
                dylanIndices.Add(0);
                break;
            case 1:
                dylanIndices.Add(oneIndices[0]);
                break;
            default:
                dylanIndices.Add(oneIndices[oneIndices.Length / 2]);
                dylanIndices.Add(oneIndices[oneIndices.Length / 2 + 1]);
                dylanIndices.Add((oneIndices[oneIndices.Length / 2] + oneIndices[oneIndices.Length / 2 + 1]) / 2);
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
