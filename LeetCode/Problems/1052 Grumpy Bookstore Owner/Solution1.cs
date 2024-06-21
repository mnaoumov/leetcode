using JetBrains.Annotations;

namespace LeetCode.Problems._1052_Grumpy_Bookstore_Owner;

/// <summary>
/// https://leetcode.com/submissions/detail/1295114461/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        var n = customers.Length;
        var prefixCustomerSumsConsideringGrumpiness = new int[n + 1];
        var prefixCustomerSums = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixCustomerSumsConsideringGrumpiness[i + 1] = prefixCustomerSumsConsideringGrumpiness[i] + customers[i] * (1 - grumpy[i]);
            prefixCustomerSums[i + 1] = prefixCustomerSums[i] + customers[i];
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var j = Math.Min(n, i + minutes);
            var result =
                prefixCustomerSumsConsideringGrumpiness[i]
                + prefixCustomerSumsConsideringGrumpiness[n]
                - prefixCustomerSumsConsideringGrumpiness[j]
                + prefixCustomerSums[j]
                - prefixCustomerSums[i];

            ans = Math.Max(ans, result);
        }

        return ans;
    }
}
