namespace LeetCode.Problems._2509_Cycle_Length_Queries_in_a_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/861446990/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] CycleLengthQueries(int n, int[][] queries) => queries.Select(Answer).ToArray();

    private readonly Dictionary<int, List<int>> _bitsMap = new();

    private int Answer(int[] query)
    {
        var bits1 = GetBits(query[0]);
        var bits2 = GetBits(query[1]);

        var commonPrefixCount = 0;

        while (commonPrefixCount < bits1.Count && commonPrefixCount < bits2.Count && bits1[commonPrefixCount] == bits2[commonPrefixCount])
        {
            commonPrefixCount++;
        }

        return bits1.Count + bits2.Count - 2 * commonPrefixCount + 1;
    }

    private List<int> GetBits(int n)
    {
        if (_bitsMap.TryGetValue(n, out var bits1))
        {
            return bits1;
        }

        var bits = new List<int>();

        while (n > 0)
        {
            bits.Insert(0, n & 1);
            n >>= 1;
        }

        return _bitsMap[n] = bits;
    }
}
