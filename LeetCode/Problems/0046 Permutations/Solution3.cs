using JetBrains.Annotations;

namespace LeetCode._0046_Permutations;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        var permutation = new List<int>();
        var set = new HashSet<int>();
        Backtrack();
        return result;

        void Backtrack()
        {
            if (permutation.Count == nums.Length)
            {
                result.Add(permutation.ToArray());
                return;
            }

            foreach (var num in nums)
            {
                if (!set.Add(num))
                {
                    continue;
                }

                permutation.Add(num);
                Backtrack();
                permutation.RemoveAt(permutation.Count - 1);
                set.Remove(num);
            }
        }
    }
}
