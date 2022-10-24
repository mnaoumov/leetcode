// ReSharper disable All
using JetBrains.Annotations;

namespace LeetCode._0494_Target_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/196694343/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindTargetSumWays(int[] nums, int S)
    {
        var partialResults = new Dictionary<int, int>();
        partialResults[0] = 1;

        foreach (var num in nums)
        {
            var newPartialResults = new Dictionary<int, int>();
            foreach (var key in partialResults.Keys.ToArray())
            {
                newPartialResults[key + num] = (newPartialResults.ContainsKey(key + num)
                                                   ? newPartialResults[key + num]
                                                   : 0) +
                                               partialResults[key];
                newPartialResults[key - num] = (newPartialResults.ContainsKey(key - num)
                                                   ? newPartialResults[key - num]
                                                   : 0) +
                                               partialResults[key];
            }

            partialResults = newPartialResults;
        }

        return partialResults.ContainsKey(S) ? partialResults[S] : 0;
    }
}
