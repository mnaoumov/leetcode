namespace LeetCode._0046_Permutations;

/// <summary>
/// https://leetcode.com/submissions/detail/815418450/
/// </summary>
public class Solution : ISolution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        return Enumerate(nums).ToList();
    }

    private static IEnumerable<IList<int>> Enumerate(int[] nums)
    {
        if (nums.Length == 1)
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