using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0015_3Sum;

/// <summary>
/// https://leetcode.com/problems/3sum/submissions/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        var entryKeys = new HashSet<string>();
        var firstAddendumsProcessed = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var firstAddendum = nums[i];

            if (firstAddendumsProcessed.Contains(firstAddendum))
            {
                continue;
            }

            firstAddendumsProcessed.Add(firstAddendum);

            var secondAddendumCandidates = new HashSet<int>();
            var secondAndThirdAddendumsProcessed = new HashSet<int>();

            for (int j = i + 1; j < nums.Length; j++)
            {
                var thirdAddendum = nums[j];

                if (secondAndThirdAddendumsProcessed.Contains(thirdAddendum))
                {
                    continue;
                }

                var secondAddendum = -firstAddendum - thirdAddendum;
                if (secondAddendumCandidates.Contains(secondAddendum))
                {
                    var entry = new[] { nums[i], secondAddendum, thirdAddendum };
                    var entryKey = string.Join(",", entry.OrderBy(x => x));

                    if (!entryKeys.Contains(entryKey))
                    {
                        result.Add(entry);
                        entryKeys.Add(entryKey);
                    }

                    secondAndThirdAddendumsProcessed.Add(secondAddendum);
                    secondAndThirdAddendumsProcessed.Add(thirdAddendum);
                }
                else
                {
                    secondAddendumCandidates.Add(thirdAddendum);
                }
            }
        }

        return result;
    }
}