namespace LeetCode.Problems._2557_Maximum_Number_of_Integers_to_Choose_From_a_Range_II;

/// <summary>
/// https://leetcode.com/submissions/detail/891676874/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaxCount(int[] banned, int n, long maxSum)
    {
        Array.Sort(banned);

        var sumAvailable = maxSum;
        var count = 0;

        for (var i = 0; i <= banned.Length; i++)
        {
            var min = i == 0 ? 1 : banned[i - 1] + 1;

            if (min > n)
            {
                break;
            }

            if (min > sumAvailable)
            {
                break;
            }

            var max = i < banned.Length ? banned[i] - 1 : n;

            if (min > max)
            {
                continue;
            }

            var sum = 1L * (min + max) * (max - min + 1) / 2;

            if (sum <= sumAvailable)
            {
                sumAvailable -= sum;
                count += max - min + 1;
            }
            else
            {
                var x = 2 * min - 1;
                count += (int) Math.Floor(4d * sumAvailable / (x + Math.Sqrt(x * x + 8 * sumAvailable)));
                break;
            }
        }

        return count;
    }
}
