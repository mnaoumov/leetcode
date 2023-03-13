using JetBrains.Annotations;

namespace LeetCode._2178_Maximum_Split_of_Positive_Even_Integers;

/// <summary>
/// https://leetcode.com/submissions/detail/914108382/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<long> MaximumEvenSplit(long finalSum)
    {
        if (finalSum % 2 != 0)
        {
            return Array.Empty<long>();
        }

        var result = new List<long>();
        var sum = 0L;

        var num = 2L;

        while (true)
        {
            sum += num;

            if (sum > finalSum)
            {
                result[^1] += finalSum + num - sum;
                break;
            }

            result.Add(num);
            num += 2;
        }

        return result;
    }
}
