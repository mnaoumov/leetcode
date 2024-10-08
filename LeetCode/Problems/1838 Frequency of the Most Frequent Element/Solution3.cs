namespace LeetCode.Problems._1838_Frequency_of_the_Most_Frequent_Element;

/// <summary>
/// https://leetcode.com/submissions/detail/935495032/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaxFrequency(int[] nums, int k)
    {
        var frequencies = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var uniqueNums = frequencies.Keys.OrderBy(num => num).ToArray();

        var result = 0;

        for (var i = 0; i < uniqueNums.Length; i++)
        {
            var frequency = frequencies[uniqueNums[i]];
            var increasesLeft = k;

            for (var j = i - 1; j >= 0; j--)
            {
                var diff = uniqueNums[i] - uniqueNums[j];

                if (increasesLeft < diff)
                {
                    break;
                }

                var count = Math.Min(increasesLeft / diff, frequencies[uniqueNums[j]]);
                frequency += count;
                increasesLeft -= diff * count;
            }

            result = Math.Max(result, frequency);
        }

        return result;
    }
}
