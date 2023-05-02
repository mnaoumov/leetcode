using JetBrains.Annotations;

namespace LeetCode._0015_3Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/828943697/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        var entryKeys = new HashSet<string>();
        var firstAddendaProcessed = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var firstAddendum = nums[i];

            if (firstAddendaProcessed.Contains(firstAddendum))
            {
                continue;
            }

            firstAddendaProcessed.Add(firstAddendum);

            var secondAddendumCandidates = new HashSet<int>();
            var secondAndThirdAddendaProcessed = new HashSet<int>();

            for (var j = i + 1; j < nums.Length; j++)
            {
                var thirdAddendum = nums[j];

                if (secondAndThirdAddendaProcessed.Contains(thirdAddendum))
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

                    secondAndThirdAddendaProcessed.Add(secondAddendum);
                    secondAndThirdAddendaProcessed.Add(thirdAddendum);
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
