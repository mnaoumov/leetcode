using JetBrains.Annotations;

namespace LeetCode._0046_Permutations;

/// <summary>
/// https://leetcode.com/submissions/detail/829023731/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        return Enumerate(nums).ToList();
    }

    private static IEnumerable<IList<int>> Enumerate(IReadOnlyCollection<int> nums)
    {
        if (nums.Count == 1)
        {
            yield return nums.ToList();
            yield break;
        }

        foreach (var num in nums)
        {
            var otherNums = nums.Except(new[] { num }).ToArray();

            var otherPermute = Enumerate(otherNums);
            foreach (var otherPermutation in otherPermute)
            {
                otherPermutation.Insert(0, num);
                yield return otherPermutation;
            }
        }
    }
}