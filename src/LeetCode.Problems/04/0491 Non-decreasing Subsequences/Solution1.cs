namespace LeetCode.Problems._0491_Non_decreasing_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/881545575/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        var keys = new HashSet<string>();

        return Enumerate(0)
            .Where(sequence => sequence.Count > 1)
            .Select(sequence => new { sequence, key = string.Join(",", sequence) })
            .Where(x => keys.Add(x.key))
            .Select(x => x.sequence)
            .ToArray();

        IEnumerable<IList<int>> Enumerate(int index)
        {
            if (index == nums.Length)
            {
                yield break;
            }

            yield return new[] { nums[index] };

            foreach (var nextSequence in Enumerate(index + 1))
            {
                yield return nextSequence;

                if (nextSequence[0] >= nums[index])
                {
                    yield return nextSequence.Prepend(nums[index]).ToArray();
                }
            }
        }
    }
}
