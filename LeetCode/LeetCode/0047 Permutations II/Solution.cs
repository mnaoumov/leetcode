namespace LeetCode._0047_Permutations_II;

/// <summary>
/// https://leetcode.com/submissions/detail/815499264/
/// </summary>
public class Solution : ISolution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        return Enumerate(nums).ToList();
    }

    private static IEnumerable<IList<int>> Enumerate(IList<int> nums)
    {
        if (nums.Count == 1)
        {
            yield return nums.ToList();
            yield break;
        }

        var keys = new HashSet<string>();

        var processedFirstItems = new HashSet<int>();

        for (int i = 0; i < nums.Count; i++)
        {
            var num = nums[i];
            if (!processedFirstItems.Add(num))
            {
                continue;
            }

            var otherNums = nums.ToList();
            otherNums.RemoveAt(i);

            var otherPermute = Enumerate(otherNums);
            foreach (var otherPermutation in otherPermute)
            {
                otherPermutation.Insert(0, num);

                var key = string.Join(",", otherPermutation);

                if (keys.Add(key))
                {
                    yield return otherPermutation;
                }
            }
        }
    }
}