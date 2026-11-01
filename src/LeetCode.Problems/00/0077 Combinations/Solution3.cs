namespace LeetCode.Problems._0077_Combinations;

/// <seealso href="https://leetcode.com/submissions/detail/918821417/">Submission</seealso>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        var combination = new List<int>();
        Backtrack(1);
        return result;

        void Backtrack(int i)
        {
            if (combination.Count == k)
            {
                result.Add(combination.ToArray());
            }

            for (var j = i; j <= n; j++)
            {
                combination.Add(j);
                Backtrack(j + 1);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }
}
