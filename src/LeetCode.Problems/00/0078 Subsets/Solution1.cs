namespace LeetCode.Problems._0078_Subsets;

/// <seealso href="https://leetcode.com/submissions/detail/821699063/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        return Enumerate(0).ToArray();

        IEnumerable<IList<int>> Enumerate(int startingIndex)
        {
            if (startingIndex >= nums.Length)
            {
                yield return Array.Empty<int>();
                yield break;
            }

            foreach (var tailSubset in Enumerate(startingIndex + 1))
            {
                yield return tailSubset;
                yield return new[] { nums[startingIndex] }.Concat(tailSubset).ToArray();
            }
        }
    }
}
