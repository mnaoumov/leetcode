namespace LeetCode.Problems._1310_XOR_Queries_of_a_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/1388262800/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] XorQueries(int[] arr, int[][] queries)
    {
        var n = arr.Length;
        var prefixXor = new int[n + 1];
        for (var i = 0; i < n; i++)
        {
            prefixXor[i + 1] = prefixXor[i] ^ arr[i];
        }

        return queries.Select(query => prefixXor[query[0]] ^ prefixXor[query[1] + 1]).ToArray();
    }
}
