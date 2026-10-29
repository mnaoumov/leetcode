namespace LeetCode.Problems._0216_Combination_Sum_III;

/// <summary>
/// https://leetcode.com/submissions/detail/918892654/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        var result = new List<IList<int>>();
        var combination = new List<int>();
        var sum = 0;
        Backtrack(1);
        return result;

        void Backtrack(int i)
        {
            if (combination.Count == k)
            {
                if (sum == n)
                {
                    result.Add(combination.ToArray());
                }

                return;
            }

            for (var j = i; j <= 9; j++)
            {
                if (sum + j > n)
                {
                    break;
                }

                combination.Add(j);
                sum += j;
                Backtrack(j + 1);
                combination.Remove(j);
                sum -= j;
            }
        }
    }
}
