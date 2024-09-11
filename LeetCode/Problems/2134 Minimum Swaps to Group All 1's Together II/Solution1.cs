namespace LeetCode.Problems._2134_Minimum_Swaps_to_Group_All_1_s_Together_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1341298433/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MinSwaps(int[] nums)
    {
        var zeroSequenceLengths = new List<int>();

        var isNewSequence = true;

        foreach (var num in nums)
        {
            if (num == 0)
            {
                if (isNewSequence)
                {
                    zeroSequenceLengths.Add(0);
                    isNewSequence = false;
                }

                zeroSequenceLengths[^1]++;
            }
            else
            {
                isNewSequence = true;
            }
        }

        if (zeroSequenceLengths.Count == 1)
        {
            return 0;
        }

        zeroSequenceLengths[0] += zeroSequenceLengths[^1];
        zeroSequenceLengths.RemoveAt(zeroSequenceLengths.Count - 1);
        return zeroSequenceLengths.Sum() - zeroSequenceLengths.Max();
    }
}
