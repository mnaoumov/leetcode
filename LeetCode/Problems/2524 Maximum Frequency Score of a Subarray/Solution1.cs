using JetBrains.Annotations;

namespace LeetCode.Problems._2524_Maximum_Frequency_Score_of_a_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/870782195/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    private const int Modulo = 1_000_000_007;

    public int MaxFrequencyScore(int[] nums, int k)
    {
        var frequenciesMap = new Dictionary<int, int>();

        for (var i = 0; i < k; i++)
        {
            var num = nums[i];
            frequenciesMap[num] = frequenciesMap.GetValueOrDefault(num) + 1;
        }

        var result = CalculateScore();

        for (var i = k; i < nums.Length; i++)
        {
            var previousNum = nums[i - k];
            frequenciesMap[previousNum]--;

            if (frequenciesMap[previousNum] == 0)
            {
                frequenciesMap.Remove(previousNum);
            }

            var num = nums[i];

            frequenciesMap[num] = frequenciesMap.GetValueOrDefault(num) + 1;

            result = Math.Max(result, CalculateScore());
        }

        return result;

        int CalculateScore()
        {
            var result2 = 0;

            foreach (var (num, frequency) in frequenciesMap)
            {
                result2 = (result2 + Power(num, frequency)) % Modulo;
            }

            return result2;
        }
    }

    private static int Power(int a, int b)
    {
        long result = 1;

        for (var i = 0; i < b; i++)
        {
            result = result * a % Modulo;
        }

        return (int) result;
    }
}
